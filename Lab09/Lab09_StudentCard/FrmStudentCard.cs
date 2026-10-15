using System.Drawing.Printing;
using Lab09_StudentCard.Helpers;
using Lab09_StudentCard.Models;

namespace Lab09_StudentCard;

public partial class FrmStudentCard : Form
{
    // Kích thước THỰC của thẻ khi in (thẻ ID-1: 85,6 x 54 mm), đơn vị 1/100 inch của PrintPage
    private const float PrintCardWidth = 337f;   // 85,6 mm ≈ 3,37 inch
    private static readonly float PrintCardHeight = PrintCardWidth / CardRenderer.AspectRatio;

    private Image? _avatar;                  // ảnh đang dùng (bản sao trong RAM, không khóa file)

    // "Bản chụp" dữ liệu tại thời điểm bấm In / Xem trước in
    private StudentInfo? _printInfo;
    private Image? _printPhoto;

    public FrmStudentCard()
    {
        InitializeComponent();
        ApplyTheme();

        // Giới hạn ngày sinh hợp lý
        dtpBirthDate.MinDate = new DateTime(1950, 1, 1);
        dtpBirthDate.MaxDate = DateTime.Today;
    }

    // ============================================================ giao diện màu sắc
    private static readonly Color ThemePrimary = Color.FromArgb(31, 78, 156);
    private static readonly Color ThemeText = Color.FromArgb(33, 37, 41);

    private void ApplyTheme()
    {
        BackColor = Color.FromArgb(238, 243, 250);

        // Banner tiêu đề: nền gradient xanh đậm -> xanh ngọc
        pnlHeader.Paint += (s, e) =>
        {
            using var brush = new System.Drawing.Drawing2D.LinearGradientBrush(
                pnlHeader.ClientRectangle, Color.FromArgb(18, 52, 124), Color.FromArgb(0, 150, 199), 0f);
            e.Graphics.FillRectangle(brush, pnlHeader.ClientRectangle);
            using var gold = new SolidBrush(Color.FromArgb(255, 193, 7));
            e.Graphics.FillRectangle(gold, 0, pnlHeader.Height - 4, pnlHeader.Width, 4);
        };
        lblAppTitle.Font = new Font("Segoe UI", 20f, FontStyle.Bold);
        lblAppTitle.ForeColor = Color.White;
        lblAppTitle.BackColor = Color.Transparent;
        lblAppSubtitle.Font = new Font("Segoe UI", 9.5f, FontStyle.Italic);
        lblAppSubtitle.ForeColor = Color.FromArgb(255, 224, 130);
        lblAppSubtitle.BackColor = Color.Transparent;

        // Các nhóm: nền trắng, tiêu đề xanh đậm; control con dùng chữ đen cho dễ đọc
        var groupColors = new Dictionary<GroupBox, Color>
        {
            [grpInfo] = Color.FromArgb(31, 78, 156),      // xanh dương
            [grpPhoto] = Color.FromArgb(0, 137, 150),     // ngọc
            [grpPreview] = Color.FromArgb(106, 27, 154),  // tím
            [grpActions] = Color.FromArgb(230, 108, 0),   // cam
        };
        foreach (GroupBox group in new[] { grpInfo, grpPhoto, grpPreview, grpActions })
        {
            group.BackColor = Color.White;
            group.ForeColor = groupColors[group];
            group.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            foreach (Control child in group.Controls)
            {
                child.Font = new Font("Segoe UI", 9f, FontStyle.Regular);
                child.ForeColor = ThemeText;
            }
        }
        lblPhotoHint.ForeColor = Color.Gray;
        pnlPreview.BackColor = Color.FromArgb(225, 235, 250);

        // Nút bấm: phẳng, mỗi nút một màu
        StyleButton(btnChooseImage, Color.FromArgb(0, 151, 167));   // ngọc
        StyleButton(btnReset, Color.FromArgb(245, 124, 0));         // cam
        StyleButton(btnPrintPreview, Color.FromArgb(25, 118, 210)); // xanh dương
        StyleButton(btnPrint, Color.FromArgb(46, 125, 50));         // xanh lá
        StyleButton(btnExit, Color.FromArgb(198, 40, 40));          // đỏ
    }

    private static void StyleButton(Button button, Color color)
    {
        button.FlatStyle = FlatStyle.Flat;
        button.FlatAppearance.BorderSize = 0;
        button.BackColor = color;
        button.ForeColor = Color.White;
        button.UseVisualStyleBackColor = false;
        button.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
        button.Cursor = Cursors.Hand;
        button.FlatAppearance.MouseOverBackColor = ControlPaint.Light(color, 0.25f);
        button.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(color, 0.1f);
    }

    private void FrmStudentCard_Load(object? sender, EventArgs e)
    {
        ResetForm();
    }

    private void FrmStudentCard_FormClosed(object? sender, FormClosedEventArgs e)
    {
        _avatar?.Dispose();
        _avatar = null;
    }

    // ============================================================ F1: chọn ảnh
    private void btnChooseImage_Click(object? sender, EventArgs e)
    {
        if (ofdAvatar.ShowDialog(this) != DialogResult.OK) return;

        Bitmap newImage;
        try
        {
            newImage = ImageHelper.LoadWithoutLock(ofdAvatar.FileName);
        }
        catch (Exception ex) when (ex is OutOfMemoryException or ArgumentException
                                       or IOException or UnauthorizedAccessException)
        {
            // Image.FromStream ném OutOfMemoryException/ArgumentException khi file không phải ảnh hợp lệ
            MessageBox.Show(this,
                "Không thể mở tệp đã chọn. Hãy chọn ảnh JPG, PNG hoặc BMP hợp lệ.",
                "Lỗi ảnh", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        // Gán ảnh mới TRƯỚC, rồi mới giải phóng ảnh cũ -> không bao giờ để PictureBox giữ ảnh đã Dispose
        Image? old = _avatar;
        _avatar = newImage;
        picAvatar.Image = newImage;
        old?.Dispose();

        errorProvider.SetError(picAvatar, string.Empty);
        RefreshPreview();
    }

    // ============================================================ F2: preview bằng GDI+
    private void InputChanged(object? sender, EventArgs e)
    {
        // Người dùng sửa dữ liệu -> bỏ cảnh báo lỗi của đúng ô đó và vẽ lại thẻ
        if (sender is Control c && !ReferenceEquals(c, dtpBirthDate))
            errorProvider.SetError(c, string.Empty);

        RefreshPreview();
    }

    private void RefreshPreview()
    {
        List<string> missing = GetMissingFields();
        lblPreviewStatus.ForeColor = missing.Count == 0 ? Color.SeaGreen : Color.Firebrick;
        lblPreviewStatus.Text = missing.Count == 0
            ? "Đã đủ dữ liệu bắt buộc - có thể xem trước in hoặc in thẻ."
            : "Còn thiếu: " + string.Join(", ", missing) + ".";

        pnlPreview.Invalidate();   // yêu cầu Windows gọi lại sự kiện Paint
    }

    private void pnlPreview_Paint(object? sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        Rectangle client = pnlPreview.ClientRectangle;

        if (GetMissingFields().Count > 0)
        {
            DrawPlaceholder(g, client);   // F3: chưa đủ dữ liệu thì không vẽ thẻ
            return;
        }

        RectangleF cardRect = CardRenderer.FitCardRectangle(client, margin: 6f);
        CardRenderer.Draw(g, cardRect, BuildStudentInfo(), _avatar);
    }

    private void DrawPlaceholder(Graphics g, Rectangle client)
    {
        using var pen = new Pen(Color.Gray, 2f) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
        var frame = Rectangle.Inflate(client, -12, -12);
        g.DrawRectangle(pen, frame);

        using var font = new Font(Font.FontFamily, 12f, FontStyle.Italic);
        using var format = new StringFormat
        {
            Alignment = StringAlignment.Center,
            LineAlignment = StringAlignment.Center
        };
        g.DrawString("Nhập Mã sinh viên, Họ tên và chọn ảnh\r\nđể xem trước thẻ sinh viên",
            font, Brushes.DimGray, frame, format);
    }

    // ============================================================ F3: validation
    private StudentInfo BuildStudentInfo() => new(
        StudentId: txtStudentId.Text.Trim(),
        FullName: txtFullName.Text.Trim(),
        ClassName: cboClass.Text.Trim(),
        Faculty: cboFaculty.Text.Trim(),
        Course: cboCourse.Text.Trim(),
        BirthDate: dtpBirthDate.Value.Date,
        Gender: cboGender.Text);

    /// <summary>Danh sách trường bắt buộc đang thiếu (kiểm tra "im lặng", không hiện thông báo).</summary>
    private List<string> GetMissingFields()
    {
        var missing = new List<string>();
        if (string.IsNullOrWhiteSpace(txtStudentId.Text)) missing.Add("Mã sinh viên");
        if (string.IsNullOrWhiteSpace(txtFullName.Text)) missing.Add("Họ tên");
        if (_avatar is null) missing.Add("Ảnh đại diện");
        return missing;
    }

    /// <summary>Kiểm tra khi bấm Xem trước in / In: hiện ErrorProvider + MessageBox, trả về true nếu hợp lệ.</summary>
    private bool ValidateInput()
    {
        errorProvider.Clear();
        Control? firstInvalid = null;

        if (string.IsNullOrWhiteSpace(txtStudentId.Text))
        {
            errorProvider.SetError(txtStudentId, "Mã sinh viên không được để trống.");
            firstInvalid ??= txtStudentId;
        }

        if (string.IsNullOrWhiteSpace(txtFullName.Text))
        {
            errorProvider.SetError(txtFullName, "Họ tên không được để trống.");
            firstInvalid ??= txtFullName;
        }

        if (_avatar is null)
        {
            errorProvider.SetError(picAvatar, "Chưa chọn ảnh đại diện.");
            firstInvalid ??= btnChooseImage;
        }

        if (firstInvalid is null) return true;

        MessageBox.Show(this,
            "Vui lòng nhập đủ dữ liệu bắt buộc: " + string.Join(", ", GetMissingFields()) + ".",
            "Thiếu dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        firstInvalid.Focus();
        return false;
    }

    // ============================================================ F4: Print Preview
    private void btnPrintPreview_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput()) return;
        TakePrintSnapshot();

        try
        {
            using var dialog = new PrintPreviewDialog
            {
                Document = printDocCard,
                UseAntiAlias = true,
                StartPosition = FormStartPosition.CenterParent,
                Width = 900,
                Height = 700
            };
            dialog.ShowDialog(this);
        }
        catch (InvalidPrinterException)
        {
            ShowNoPrinterMessage();
        }
    }

    // ============================================================ F5: Print
    private void btnPrint_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput()) return;
        TakePrintSnapshot();

        try
        {
            if (prtDialog.ShowDialog(this) == DialogResult.OK)
                printDocCard.Print();
        }
        catch (InvalidPrinterException)
        {
            ShowNoPrinterMessage();
        }
    }

    private void TakePrintSnapshot()
    {
        _printInfo = BuildStudentInfo();
        _printPhoto = _avatar;
        printDocCard.DocumentName = "The sinh vien - " + _printInfo.StudentId;
    }

    private void ShowNoPrinterMessage()
    {
        MessageBox.Show(this,
            "Không tìm thấy máy in. Hãy cài đặt/chọn một máy in (ví dụ Microsoft Print to PDF) rồi thử lại.",
            "Không có máy in", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    /// <summary>
    /// PrintPage chạy cho từng trang (cả khi xem trước lẫn khi in thật).
    /// Đơn vị của e.Graphics ở đây là 1/100 inch.
    /// </summary>
    private void printDocCard_PrintPage(object? sender, PrintPageEventArgs e)
    {
        e.HasMorePages = false;
        if (e.Graphics is null || _printInfo is null) return;

        Graphics g = e.Graphics;
        RectangleF margin = e.MarginBounds;

        // Thẻ in đúng kích thước thực, căn giữa theo chiều ngang, đặt phía trên trang
        var cardRect = new RectangleF(
            margin.Left + (margin.Width - PrintCardWidth) / 2f,
            margin.Top,
            PrintCardWidth,
            PrintCardHeight);

        CardRenderer.Draw(g, cardRect, _printInfo, _printPhoto);

        // Ghi chú nhỏ bên dưới thẻ
        using var noteFont = new Font("Segoe UI", 9f, FontStyle.Italic);
        using var format = new StringFormat { Alignment = StringAlignment.Center };
        g.DrawString("Kích thước thực 85,6 x 54 mm - cắt theo khung ngoài của thẻ.",
            noteFont, Brushes.Gray,
            new RectangleF(margin.Left, cardRect.Bottom + 12f, margin.Width, 30f), format);
    }

    // ============================================================ F6: làm mới
    private void btnReset_Click(object? sender, EventArgs e)
    {
        ResetForm();
    }

    private void ResetForm()
    {
        txtStudentId.Clear();
        txtFullName.Clear();
        cboGender.SelectedIndex = 0;
        cboClass.SelectedIndex = 0;
        cboFaculty.SelectedIndex = 0;
        int k49 = cboCourse.Items.IndexOf("K49");
        cboCourse.SelectedIndex = k49 >= 0 ? k49 : 0;
        dtpBirthDate.Value = DateTime.Today.AddYears(-20);

        // Xóa ảnh: bỏ tham chiếu ở PictureBox trước rồi mới Dispose
        picAvatar.Image = null;
        _avatar?.Dispose();
        _avatar = null;
        _printPhoto = null;
        _printInfo = null;

        errorProvider.Clear();
        RefreshPreview();
        txtStudentId.Focus();
    }

    private void btnExit_Click(object? sender, EventArgs e)
    {
        Close();
    }
}

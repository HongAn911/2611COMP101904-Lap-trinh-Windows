namespace Lab09_StudentCard;

partial class FrmStudentCard
{
    private System.ComponentModel.IContainer? components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && components != null)
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();

        // ---- khởi tạo control
        pnlHeader = new Panel();
        lblAppTitle = new Label();
        lblAppSubtitle = new Label();

        grpInfo = new GroupBox();
        lblStudentId = new Label();
        txtStudentId = new TextBox();
        lblFullName = new Label();
        txtFullName = new TextBox();
        lblBirthDate = new Label();
        dtpBirthDate = new DateTimePicker();
        lblGender = new Label();
        cboGender = new ComboBox();
        lblClass = new Label();
        cboClass = new ComboBox();
        lblFaculty = new Label();
        cboFaculty = new ComboBox();
        lblCourse = new Label();
        cboCourse = new ComboBox();

        grpPhoto = new GroupBox();
        picAvatar = new PictureBox();
        btnChooseImage = new Button();
        lblPhotoHint = new Label();

        grpPreview = new GroupBox();
        pnlPreview = new CustomControls.DoubleBufferedPanel();
        lblPreviewStatus = new Label();

        grpActions = new GroupBox();
        btnReset = new Button();
        btnPrintPreview = new Button();
        btnPrint = new Button();
        btnExit = new Button();

        ofdAvatar = new OpenFileDialog();
        printDocCard = new System.Drawing.Printing.PrintDocument();
        prtDialog = new PrintDialog();
        errorProvider = new ErrorProvider(components);

        grpInfo.SuspendLayout();
        grpPhoto.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
        grpPreview.SuspendLayout();
        grpActions.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)errorProvider).BeginInit();
        SuspendLayout();

        // ================= pnlHeader (banner tiêu đề) =================
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Height = 72;
        pnlHeader.Controls.AddRange(new Control[] { lblAppTitle, lblAppSubtitle });

        lblAppTitle.Name = "lblAppTitle";
        lblAppTitle.AutoSize = true;
        lblAppTitle.Text = "THẺ SINH VIÊN";
        lblAppTitle.Location = new Point(20, 6);

        lblAppSubtitle.Name = "lblAppSubtitle";
        lblAppSubtitle.AutoSize = true;
        lblAppSubtitle.Text = "Lab 09 - COMP1019 | Thiết kế và in thẻ sinh viên bằng WinForms (GDI+)";
        lblAppSubtitle.Location = new Point(24, 44);

        // ================= grpInfo =================
        grpInfo.Text = "Thông tin sinh viên";
        grpInfo.Location = new Point(12, 88);
        grpInfo.Size = new Size(470, 322);
        grpInfo.Controls.AddRange(new Control[]
        {
            lblStudentId, txtStudentId, lblFullName, txtFullName, lblBirthDate, dtpBirthDate,
            lblGender, cboGender, lblClass, cboClass, lblFaculty, cboFaculty, lblCourse, cboCourse
        });

        // hàng 1: Mã sinh viên
        lblStudentId.AutoSize = true;
        lblStudentId.Text = "Mã sinh viên (*)";
        lblStudentId.Location = new Point(15, 36);
        txtStudentId.Name = "txtStudentId";
        txtStudentId.Location = new Point(125, 32);
        txtStudentId.Size = new Size(325, 23);
        txtStudentId.MaxLength = 20;
        txtStudentId.TextChanged += InputChanged;

        // hàng 2: Họ và tên
        lblFullName.AutoSize = true;
        lblFullName.Text = "Họ và tên (*)";
        lblFullName.Location = new Point(15, 76);
        txtFullName.Name = "txtFullName";
        txtFullName.Location = new Point(125, 72);
        txtFullName.Size = new Size(325, 23);
        txtFullName.MaxLength = 60;
        txtFullName.TextChanged += InputChanged;

        // hàng 3: Ngày sinh
        lblBirthDate.AutoSize = true;
        lblBirthDate.Text = "Ngày sinh";
        lblBirthDate.Location = new Point(15, 116);
        dtpBirthDate.Name = "dtpBirthDate";
        dtpBirthDate.Format = DateTimePickerFormat.Custom;
        dtpBirthDate.CustomFormat = "dd/MM/yyyy";
        dtpBirthDate.Location = new Point(125, 112);
        dtpBirthDate.Size = new Size(150, 23);
        dtpBirthDate.ValueChanged += InputChanged;

        // hàng 4: Giới tính
        lblGender.AutoSize = true;
        lblGender.Text = "Giới tính";
        lblGender.Location = new Point(15, 156);
        cboGender.Name = "cboGender";
        cboGender.DropDownStyle = ComboBoxStyle.DropDownList;
        cboGender.Items.AddRange(new object[] { "Nam", "Nữ", "Khác" });
        cboGender.Location = new Point(125, 152);
        cboGender.Size = new Size(150, 23);
        cboGender.SelectedIndexChanged += InputChanged;

        // hàng 5: Lớp
        lblClass.AutoSize = true;
        lblClass.Text = "Lớp";
        lblClass.Location = new Point(15, 196);
        cboClass.Name = "cboClass";
        cboClass.DropDownStyle = ComboBoxStyle.DropDown;
        cboClass.Items.AddRange(new object[]
        {
            "49.01.SPTIN.A", "49.01.SPTIN.B", "49.01.SPTOAN.A", "50.01.SPTIN.A", "51.01.SPTIN.A"
        });
        cboClass.MaxLength = 30;
        cboClass.Location = new Point(125, 192);
        cboClass.Size = new Size(325, 23);
        cboClass.TextChanged += InputChanged;

        // hàng 6: Khoa
        lblFaculty.AutoSize = true;
        lblFaculty.Text = "Khoa";
        lblFaculty.Location = new Point(15, 236);
        cboFaculty.Name = "cboFaculty";
        cboFaculty.DropDownStyle = ComboBoxStyle.DropDown;
        cboFaculty.Items.AddRange(new object[]
        {
            "Công nghệ thông tin", "Toán - Tin học", "Vật lý", "Hóa học", "Ngữ văn", "Giáo dục Tiểu học"
        });
        cboFaculty.MaxLength = 50;
        cboFaculty.Location = new Point(125, 232);
        cboFaculty.Size = new Size(325, 23);
        cboFaculty.TextChanged += InputChanged;

        // hàng 7: Khóa học
        lblCourse.AutoSize = true;
        lblCourse.Text = "Khóa học";
        lblCourse.Location = new Point(15, 276);
        cboCourse.Name = "cboCourse";
        cboCourse.DropDownStyle = ComboBoxStyle.DropDownList;
        cboCourse.Items.AddRange(new object[] { "K48", "K49", "K50", "K51" });
        cboCourse.Location = new Point(125, 272);
        cboCourse.Size = new Size(150, 23);
        cboCourse.SelectedIndexChanged += InputChanged;

        // ================= grpPhoto =================
        grpPhoto.Text = "Ảnh đại diện";
        grpPhoto.Location = new Point(12, 418);
        grpPhoto.Size = new Size(470, 246);
        grpPhoto.Controls.AddRange(new Control[] { picAvatar, btnChooseImage, lblPhotoHint });

        picAvatar.Name = "picAvatar";
        picAvatar.Location = new Point(125, 26);
        picAvatar.Size = new Size(165, 200);
        picAvatar.SizeMode = PictureBoxSizeMode.Zoom;   // F1: hiển thị theo chế độ Zoom (giữ tỉ lệ)
        picAvatar.BorderStyle = BorderStyle.FixedSingle;
        picAvatar.BackColor = Color.White;
        picAvatar.TabStop = false;

        btnChooseImage.Name = "btnChooseImage";
        btnChooseImage.Text = "Chọn ảnh...";
        btnChooseImage.Location = new Point(305, 26);
        btnChooseImage.Size = new Size(145, 38);
        btnChooseImage.UseVisualStyleBackColor = true;
        btnChooseImage.Click += btnChooseImage_Click;

        lblPhotoHint.AutoSize = true;
        lblPhotoHint.ForeColor = SystemColors.GrayText;
        lblPhotoHint.Text = "Hỗ trợ: JPG, JPEG, PNG, BMP";
        lblPhotoHint.Location = new Point(305, 72);

        // ================= grpPreview =================
        grpPreview.Text = "Xem trước thẻ sinh viên";
        grpPreview.Location = new Point(494, 88);
        grpPreview.Size = new Size(614, 436);
        grpPreview.Controls.AddRange(new Control[] { pnlPreview, lblPreviewStatus });

        pnlPreview.Name = "pnlPreview";
        pnlPreview.Location = new Point(12, 28);
        pnlPreview.Size = new Size(590, 372);
        pnlPreview.BackColor = Color.FromArgb(236, 239, 243);
        pnlPreview.BorderStyle = BorderStyle.FixedSingle;
        pnlPreview.Paint += pnlPreview_Paint;           // F2: vẽ thẻ bằng GDI+ trong Paint event

        lblPreviewStatus.Name = "lblPreviewStatus";
        lblPreviewStatus.AutoSize = true;
        lblPreviewStatus.Location = new Point(14, 408);
        lblPreviewStatus.Text = string.Empty;

        // ================= grpActions =================
        grpActions.Text = "Điều khiển";
        grpActions.Location = new Point(494, 532);
        grpActions.Size = new Size(614, 132);
        grpActions.Controls.AddRange(new Control[] { btnReset, btnPrintPreview, btnPrint, btnExit });

        btnReset.Name = "btnReset";
        btnReset.Text = "Làm mới";
        btnReset.Location = new Point(14, 40);
        btnReset.Size = new Size(135, 48);
        btnReset.UseVisualStyleBackColor = true;
        btnReset.Click += btnReset_Click;

        btnPrintPreview.Name = "btnPrintPreview";
        btnPrintPreview.Text = "Xem trước in";
        btnPrintPreview.Location = new Point(159, 40);
        btnPrintPreview.Size = new Size(135, 48);
        btnPrintPreview.UseVisualStyleBackColor = true;
        btnPrintPreview.Click += btnPrintPreview_Click;

        btnPrint.Name = "btnPrint";
        btnPrint.Text = "In thẻ";
        btnPrint.Location = new Point(304, 40);
        btnPrint.Size = new Size(135, 48);
        btnPrint.UseVisualStyleBackColor = true;
        btnPrint.Click += btnPrint_Click;

        btnExit.Name = "btnExit";
        btnExit.Text = "Thoát";
        btnExit.Location = new Point(449, 40);
        btnExit.Size = new Size(135, 48);
        btnExit.UseVisualStyleBackColor = true;
        btnExit.Click += btnExit_Click;

        // ================= dialog / component =================
        ofdAvatar.Title = "Chọn ảnh đại diện";
        ofdAvatar.Filter =
            "Tất cả ảnh (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp|" +
            "JPG / JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
            "PNG (*.png)|*.png|" +
            "BMP (*.bmp)|*.bmp";
        ofdAvatar.FilterIndex = 1;
        ofdAvatar.CheckFileExists = true;
        ofdAvatar.Multiselect = false;

        printDocCard.DocumentName = "The sinh vien";
        printDocCard.PrintPage += printDocCard_PrintPage;

        prtDialog.Document = printDocCard;
        prtDialog.AllowSomePages = false;
        prtDialog.AllowSelection = false;

        errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        errorProvider.ContainerControl = this;

        // ================= FrmStudentCard =================
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1120, 676);
        Controls.AddRange(new Control[] { pnlHeader, grpInfo, grpPhoto, grpPreview, grpActions });
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "FrmStudentCard";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Lab 09 - Thiết kế và in thẻ sinh viên";
        Load += FrmStudentCard_Load;
        FormClosed += FrmStudentCard_FormClosed;

        grpInfo.ResumeLayout(false);
        grpInfo.PerformLayout();
        grpPhoto.ResumeLayout(false);
        grpPhoto.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
        grpPreview.ResumeLayout(false);
        grpPreview.PerformLayout();
        grpActions.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)errorProvider).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlHeader;
    private Label lblAppTitle;
    private Label lblAppSubtitle;

    private GroupBox grpInfo;
    private Label lblStudentId;
    private TextBox txtStudentId;
    private Label lblFullName;
    private TextBox txtFullName;
    private Label lblBirthDate;
    private DateTimePicker dtpBirthDate;
    private Label lblGender;
    private ComboBox cboGender;
    private Label lblClass;
    private ComboBox cboClass;
    private Label lblFaculty;
    private ComboBox cboFaculty;
    private Label lblCourse;
    private ComboBox cboCourse;

    private GroupBox grpPhoto;
    private PictureBox picAvatar;
    private Button btnChooseImage;
    private Label lblPhotoHint;

    private GroupBox grpPreview;
    private CustomControls.DoubleBufferedPanel pnlPreview;
    private Label lblPreviewStatus;

    private GroupBox grpActions;
    private Button btnReset;
    private Button btnPrintPreview;
    private Button btnPrint;
    private Button btnExit;

    private OpenFileDialog ofdAvatar;
    private System.Drawing.Printing.PrintDocument printDocCard;
    private PrintDialog prtDialog;
    private ErrorProvider errorProvider;
}

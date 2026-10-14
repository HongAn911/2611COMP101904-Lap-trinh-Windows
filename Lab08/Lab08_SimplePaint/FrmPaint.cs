using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace COMP1019_Lab08_SimplePaint
{
    /// <summary>
    /// Form chính của ứng dụng Simple Paint (WinForms + GDI+).
    /// Nguyên tắc: mọi nét vẽ được lưu trong List&lt;DrawItem&gt; và chỉ được vẽ trong sự kiện Paint của canvas.
    /// </summary>
    public class FrmPaint : Form
    {
        // ====== Control bắt buộc (đặt tên theo đề bài) ======
        private readonly DrawSurface canvas = new DrawSurface();
        private readonly ComboBox cboMode = new ComboBox();
        private readonly NumericUpDown nudWidth = new NumericUpDown();
        private readonly Button btnColor = new Button();
        private readonly Button btnUndo = new Button();
        private readonly Button btnClear = new Button();
        private readonly Label lblStatus = new Label();

        // ====== Control cho chức năng nâng cao ======
        private readonly CheckBox chkFill = new CheckBox();
        private readonly Button btnBackColor = new Button();
        private readonly Button btnOpenImage = new Button();
        private readonly Button btnSave = new Button();

        // ====== Dữ liệu ======
        private readonly List<DrawItem> items = new List<DrawItem>();   // các nét đã vẽ xong
        private DrawItem currentItem;                                    // nét đang kéo chuột
        private bool isDrawing = false;
        private Color currentColor = Color.Black;
        private Bitmap backgroundImage;                                  // ảnh nền (nâng cao)

        public FrmPaint()
        {
            Text = "Simple Paint";
            Width = 1000;
            Height = 650;
            MinimumSize = new Size(820, 450);
            StartPosition = FormStartPosition.CenterScreen;
            KeyPreview = true;

            BuildUserInterface();
            RegisterEvents();
            UpdateColorButton();
        }

        // =====================================================================
        // Xây dựng giao diện
        // =====================================================================
        private static readonly Color ToolbarColor = Color.FromArgb(70, 130, 180);   // xanh thép
        private static readonly Color StatusColor = Color.FromArgb(240, 244, 248);

        private void BuildUserInterface()
        {
            // Co giãn theo DPI để nút không bị cắt khi Windows scale 125% / 150%
            AutoScaleMode = AutoScaleMode.Dpi;
            Font = new Font("Segoe UI", 9.5f);

            // Thanh công cụ tự tính chiều cao theo nội dung (không đặt cứng Height)
            FlowLayoutPanel topPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                WrapContents = true,
                Padding = new Padding(10, 8, 10, 8),
                BackColor = ToolbarColor
            };

            cboMode.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMode.FlatStyle = FlatStyle.Flat;
            foreach (DrawMode mode in Enum.GetValues(typeof(DrawMode)))
                cboMode.Items.Add(mode.ToString());
            cboMode.SelectedIndex = 0;
            cboMode.Width = 110;
            cboMode.Margin = new Padding(3, 6, 8, 3);

            nudWidth.Minimum = 1;
            nudWidth.Maximum = 20;
            nudWidth.Value = 3;
            nudWidth.Width = 55;
            nudWidth.Margin = new Padding(3, 6, 12, 3);

            chkFill.Text = "Tô màu";
            chkFill.AutoSize = true;
            chkFill.ForeColor = Color.White;
            chkFill.Font = new Font(Font, FontStyle.Bold);
            chkFill.Margin = new Padding(6, 8, 12, 3);

            StyleButton(btnColor, "Chọn màu", Color.Teal, Color.White, true);
            StyleButton(btnUndo, "Undo", Color.DarkGreen, Color.White, true);
            StyleButton(btnClear, "Clear", Color.Red, Color.White, true);
            StyleButton(btnBackColor, "Màu nền", Color.White, Color.FromArgb(30, 40, 50), false);
            StyleButton(btnOpenImage, "Mở ảnh nền", Color.White, Color.FromArgb(30, 40, 50), false);
            StyleButton(btnSave, "Lưu PNG", Color.White, Color.FromArgb(30, 40, 50), false);

            topPanel.Controls.Add(CreateCaption("Chế độ:"));
            topPanel.Controls.Add(cboMode);
            topPanel.Controls.Add(CreateCaption("Độ dày:"));
            topPanel.Controls.Add(nudWidth);
            topPanel.Controls.Add(btnColor);
            topPanel.Controls.Add(btnUndo);
            topPanel.Controls.Add(btnClear);
            topPanel.Controls.Add(chkFill);
            topPanel.Controls.Add(btnBackColor);
            topPanel.Controls.Add(btnOpenImage);
            topPanel.Controls.Add(btnSave);

            lblStatus.Dock = DockStyle.Bottom;
            lblStatus.Height = 28;
            lblStatus.Text = "Ready";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            lblStatus.Padding = new Padding(10, 0, 0, 0);
            lblStatus.BackColor = StatusColor;
            lblStatus.ForeColor = Color.FromArgb(50, 60, 70);

            // Thứ tự Add: canvas (Fill) trước, sau đó mới tới Bottom / Top
            Controls.Add(canvas);
            Controls.Add(lblStatus);
            Controls.Add(topPanel);

            ToolTip tip = new ToolTip();
            tip.SetToolTip(btnUndo, "Xóa nét vẽ gần nhất (Ctrl+Z)");
            tip.SetToolTip(btnClear, "Xóa toàn bộ nét vẽ");
            tip.SetToolTip(btnColor, "Chọn màu vẽ");
            tip.SetToolTip(btnBackColor, "Đổi màu nền canvas");
            tip.SetToolTip(btnOpenImage, "Mở ảnh nền để vẽ đè lên (Ctrl+O)");
            tip.SetToolTip(btnSave, "Lưu vùng vẽ ra PNG (Ctrl+S)");
        }

        /// <summary>Tạo kiểu nút phẳng, viền trắng, kích thước đồng nhất.</summary>
        private static void StyleButton(Button button, string text, Color back, Color fore, bool bold)
        {
            button.Text = text;
            button.AutoSize = true;
            button.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button.MinimumSize = new Size(80, 32);
            button.Padding = new Padding(8, 0, 8, 0);
            button.Margin = new Padding(4, 3, 4, 3);
            button.Cursor = Cursors.Hand;
            button.UseVisualStyleBackColor = false;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = Color.White;
            button.FlatAppearance.BorderSize = 1;
            button.BackColor = back;
            button.ForeColor = fore;
            button.FlatAppearance.MouseOverBackColor = ControlPaint.Light(back, 0.3f);
            button.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(back, 0.1f);
            button.Font = new Font("Segoe UI", 9.5f, bold ? FontStyle.Bold : FontStyle.Regular);
        }

        private static Label CreateCaption(string text)
        {
            return new Label
            {
                Text = text,
                AutoSize = true,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9.5f, FontStyle.Bold),
                Margin = new Padding(6, 10, 2, 0)
            };
        }

        private void RegisterEvents()
        {
            canvas.Paint += Canvas_Paint;
            canvas.MouseDown += Canvas_MouseDown;
            canvas.MouseMove += Canvas_MouseMove;
            canvas.MouseUp += Canvas_MouseUp;
            canvas.MouseLeave += Canvas_MouseLeave;

            btnColor.Click += BtnColor_Click;
            btnUndo.Click += BtnUndo_Click;
            btnClear.Click += BtnClear_Click;
            btnBackColor.Click += BtnBackColor_Click;
            btnOpenImage.Click += BtnOpenImage_Click;
            btnSave.Click += BtnSave_Click;

            FormClosed += FrmPaint_FormClosed;
        }

        // =====================================================================
        // Thuộc tính tiện ích
        // =====================================================================
        private DrawMode CurrentMode
        {
            get
            {
                if (cboMode.SelectedItem != null &&
                    Enum.TryParse(cboMode.SelectedItem.ToString(), out DrawMode mode))
                {
                    return mode;
                }
                return DrawMode.Pen;   // giá trị mặc định an toàn
            }
        }

        // =====================================================================
        // Xử lý nút
        // =====================================================================
        private void BtnColor_Click(object sender, EventArgs e)
        {
            using ColorDialog dialog = new ColorDialog();
            dialog.Color = currentColor;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = dialog.Color;
                UpdateColorButton();
            }
        }

        private void UpdateColorButton()
        {
            // Nút hiển thị đúng màu đang chọn; chữ đổi trắng/đen để luôn đọc được
            btnColor.BackColor = currentColor;
            btnColor.ForeColor = currentColor.GetBrightness() < 0.55f ? Color.White : Color.Black;
            btnColor.FlatAppearance.MouseOverBackColor = ControlPaint.Light(currentColor, 0.3f);
            btnColor.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(currentColor, 0.1f);
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            UndoLastItem();
        }

        private void UndoLastItem()
        {
            if (isDrawing) return;   // không undo khi đang kéo chuột

            if (items.Count == 0)
            {
                lblStatus.Text = "Không còn nét vẽ nào để Undo.";
                return;
            }

            items.RemoveAt(items.Count - 1);
            canvas.Invalidate();
            lblStatus.Text = $"Đã Undo. Còn {items.Count} nét vẽ.";
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            if (isDrawing) return;

            if (items.Count == 0)
            {
                lblStatus.Text = "Canvas đang trống.";
                return;
            }

            DialogResult result = MessageBox.Show(
                "Xóa toàn bộ vùng vẽ?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                items.Clear();
                canvas.Invalidate();
                lblStatus.Text = "Đã xóa toàn bộ nét vẽ.";
            }
        }

        // ----- Nâng cao: đổi màu nền canvas -----
        private void BtnBackColor_Click(object sender, EventArgs e)
        {
            using ColorDialog dialog = new ColorDialog();
            dialog.Color = canvas.BackColor;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                canvas.BackColor = dialog.Color;   // BackColor đổi sẽ tự Invalidate canvas
            }
        }

        // ----- Nâng cao: mở ảnh nền để vẽ đè lên -----
        private void BtnOpenImage_Click(object sender, EventArgs e)
        {
            using OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Chọn ảnh nền";
            dialog.Filter = "Image files|*.png;*.jpg;*.jpeg;*.bmp;*.gif|All files|*.*";

            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                // Đọc qua Image.FromFile rồi copy sang Bitmap mới để không bị khóa file.
                using Image source = Image.FromFile(dialog.FileName);
                Bitmap fitted = FitToCanvas(source);

                backgroundImage?.Dispose();
                backgroundImage = fitted;
                canvas.Invalidate();
                lblStatus.Text = "Đã mở ảnh nền: " + System.IO.Path.GetFileName(dialog.FileName);
            }
            catch (Exception ex) when (ex is OutOfMemoryException ||
                                       ex is System.IO.IOException ||
                                       ex is ArgumentException)
            {
                MessageBox.Show("Không thể mở ảnh này.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>Thu nhỏ ảnh (nếu lớn hơn canvas) và giữ tỉ lệ; ảnh được đặt ở góc trên bên trái.</summary>
        private Bitmap FitToCanvas(Image source)
        {
            float scale = 1f;
            if (canvas.ClientSize.Width > 0 && canvas.ClientSize.Height > 0)
            {
                scale = Math.Min(1f, Math.Min(
                    (float)canvas.ClientSize.Width / source.Width,
                    (float)canvas.ClientSize.Height / source.Height));
            }

            int w = Math.Max(1, (int)(source.Width * scale));
            int h = Math.Max(1, (int)(source.Height * scale));

            Bitmap result = new Bitmap(w, h);
            using Graphics g = Graphics.FromImage(result);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(source, 0, 0, w, h);
            return result;
        }

        // ----- Nâng cao: lưu vùng vẽ ra PNG -----
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (canvas.ClientSize.Width <= 0 || canvas.ClientSize.Height <= 0)
            {
                MessageBox.Show("Vùng vẽ không hợp lệ để lưu.", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Lưu hình vẽ";
            dialog.Filter = "PNG image|*.png";
            dialog.FileName = "painting.png";

            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                using Bitmap bitmap = new Bitmap(canvas.ClientSize.Width, canvas.ClientSize.Height);
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.Clear(canvas.BackColor);
                    RenderScene(g);
                }
                bitmap.Save(dialog.FileName, ImageFormat.Png);
                lblStatus.Text = "Đã lưu: " + dialog.FileName;
            }
            catch (Exception ex) when (ex is System.IO.IOException ||
                                       ex is UnauthorizedAccessException ||
                                       ex is System.Runtime.InteropServices.ExternalException)
            {
                MessageBox.Show("Không thể lưu file.\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----- Nâng cao: phím tắt Ctrl+Z / Ctrl+S / Ctrl+O -----
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.Z:
                    UndoLastItem();
                    return true;
                case Keys.Control | Keys.S:
                    BtnSave_Click(this, EventArgs.Empty);
                    return true;
                case Keys.Control | Keys.O:
                    BtnOpenImage_Click(this, EventArgs.Empty);
                    return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void FrmPaint_FormClosed(object sender, FormClosedEventArgs e)
        {
            backgroundImage?.Dispose();
            backgroundImage = null;
        }

        // =====================================================================
        // Xử lý chuột trên canvas
        // =====================================================================
        private void Canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;   // chuột phải/giữa không tạo nét vẽ

            isDrawing = true;

            currentItem = new DrawItem
            {
                Mode = CurrentMode,
                Start = e.Location,
                End = e.Location,
                Color = currentColor,
                Width = (float)nudWidth.Value,
                Filled = chkFill.Checked
            };

            if (currentItem.Mode == DrawMode.Pen)
                currentItem.Points.Add(e.Location);

            canvas.Invalidate();   // để một cú click đơn cũng hiện chấm ngay
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            lblStatus.Text = $"X = {e.X}, Y = {e.Y}   |   Mode: {CurrentMode}   |   Items = {items.Count}";

            if (!isDrawing || currentItem == null) return;

            currentItem.End = e.Location;

            if (currentItem.Mode == DrawMode.Pen)
            {
                // bỏ qua điểm trùng để danh sách không phình to vô ích
                List<Point> pts = currentItem.Points;
                if (pts.Count == 0 || pts[pts.Count - 1] != e.Location)
                    pts.Add(e.Location);
            }

            canvas.Invalidate();
        }

        private void Canvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isDrawing || currentItem == null) return;
            if (e.Button != MouseButtons.Left) return;

            currentItem.End = e.Location;
            if (currentItem.Mode == DrawMode.Pen && currentItem.Points.Count > 0 &&
                currentItem.Points[currentItem.Points.Count - 1] != e.Location)
            {
                currentItem.Points.Add(e.Location);
            }

            items.Add(currentItem);

            currentItem = null;
            isDrawing = false;
            canvas.Invalidate();
        }

        private void Canvas_MouseLeave(object sender, EventArgs e)
        {
            if (!isDrawing)
                lblStatus.Text = "Ready";
        }

        // =====================================================================
        // Vẽ lại (chỉ vẽ trong sự kiện Paint)
        // =====================================================================
        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            RenderScene(e.Graphics);
        }

        /// <summary>
        /// Vẽ ảnh nền + toàn bộ DrawItem + nét đang kéo lên đối tượng Graphics.
        /// Dùng chung cho Paint event và chức năng Save PNG.
        /// </summary>
        private void RenderScene(Graphics g)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (backgroundImage != null)
                g.DrawImage(backgroundImage, 0, 0, backgroundImage.Width, backgroundImage.Height);

            foreach (DrawItem item in items)
                DrawOneItem(g, item);

            if (currentItem != null)
                DrawOneItem(g, currentItem);
        }

        private void DrawOneItem(Graphics g, DrawItem item)
        {
            using Pen pen = new Pen(item.Color, item.Width);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.Round;
            pen.LineJoin = LineJoin.Round;

            Rectangle rect = GetRectangle(item.Start, item.End);

            switch (item.Mode)
            {
                case DrawMode.Pen:
                    DrawFreePen(g, pen, item);
                    break;

                case DrawMode.Line:
                    g.DrawLine(pen, item.Start, item.End);
                    break;

                case DrawMode.Rectangle:
                    if (item.Filled)
                    {
                        using SolidBrush brush = new SolidBrush(item.Color);
                        g.FillRectangle(brush, rect);
                    }
                    g.DrawRectangle(pen, rect);
                    break;

                case DrawMode.Ellipse:
                    if (item.Filled)
                    {
                        using SolidBrush brush = new SolidBrush(item.Color);
                        g.FillEllipse(brush, rect);
                    }
                    g.DrawEllipse(pen, rect);
                    break;
            }
        }

        private void DrawFreePen(Graphics g, Pen pen, DrawItem item)
        {
            List<Point> points = item.Points;

            if (points.Count == 0) return;

            if (points.Count == 1)
            {
                // chỉ click một lần: vẽ một chấm tròn có đường kính = độ dày nét
                using SolidBrush dot = new SolidBrush(item.Color);
                float r = item.Width / 2f;
                g.FillEllipse(dot, points[0].X - r, points[0].Y - r, item.Width, item.Width);
                return;
            }

            g.DrawLines(pen, points.ToArray());
        }

        /// <summary>
        /// Tạo Rectangle hợp lệ từ hai điểm bất kỳ, kể cả khi kéo chuột từ phải sang trái hoặc từ dưới lên trên.
        /// </summary>
        private Rectangle GetRectangle(Point start, Point end)
        {
            int x = Math.Min(start.X, end.X);
            int y = Math.Min(start.Y, end.Y);
            int width = Math.Abs(start.X - end.X);
            int height = Math.Abs(start.Y - end.Y);

            return new Rectangle(x, y, width, height);
        }
    }
}

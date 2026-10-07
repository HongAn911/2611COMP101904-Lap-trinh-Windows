namespace Lab05
{
    partial class FrmDangKyKhoaHoc
    {
        private System.ComponentModel.IContainer components = null;

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
            grpHocVien = new GroupBox();
            lblHoTen = new Label();
            txtHoTen = new TextBox();
            lblSoDienThoai = new Label();
            txtSoDienThoai = new TextBox();
            lblNgaySinh = new Label();
            dtpNgaySinh = new DateTimePicker();
            chkNhanEmail = new CheckBox();
            grpKhoaHoc = new GroupBox();
            lblKhoaHoc = new Label();
            cboKhoaHoc = new ComboBox();
            lblHinhThuc = new Label();
            radOnline = new RadioButton();
            radOffline = new RadioButton();
            lblSoThang = new Label();
            numSoThang = new NumericUpDown();
            lblNhanTongTien = new Label();
            lblTongTien = new Label();
            btnDangKy = new Button();
            btnLamMoi = new Button();
            btnThoat = new Button();
            grpHocVien.SuspendLayout();
            grpKhoaHoc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).BeginInit();
            SuspendLayout();
            //
            // grpHocVien
            //
            grpHocVien.Controls.Add(lblHoTen);
            grpHocVien.Controls.Add(txtHoTen);
            grpHocVien.Controls.Add(lblSoDienThoai);
            grpHocVien.Controls.Add(txtSoDienThoai);
            grpHocVien.Controls.Add(lblNgaySinh);
            grpHocVien.Controls.Add(dtpNgaySinh);
            grpHocVien.Controls.Add(chkNhanEmail);
            grpHocVien.Location = new Point(15, 15);
            grpHocVien.Name = "grpHocVien";
            grpHocVien.Size = new Size(555, 185);
            grpHocVien.TabIndex = 0;
            grpHocVien.TabStop = false;
            grpHocVien.Text = "Thông tin học viên";
            //
            // lblHoTen
            //
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(20, 38);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Text = "Họ tên:";
            //
            // txtHoTen
            //
            txtHoTen.Location = new Point(160, 35);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(370, 27);
            txtHoTen.TabIndex = 0;
            //
            // lblSoDienThoai
            //
            lblSoDienThoai.AutoSize = true;
            lblSoDienThoai.Location = new Point(20, 77);
            lblSoDienThoai.Name = "lblSoDienThoai";
            lblSoDienThoai.Text = "Số điện thoại:";
            //
            // txtSoDienThoai
            //
            txtSoDienThoai.Location = new Point(160, 74);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(370, 27);
            txtSoDienThoai.TabIndex = 1;
            //
            // lblNgaySinh
            //
            lblNgaySinh.AutoSize = true;
            lblNgaySinh.Location = new Point(20, 116);
            lblNgaySinh.Name = "lblNgaySinh";
            lblNgaySinh.Text = "Ngày sinh:";
            //
            // dtpNgaySinh
            //
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(160, 113);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(170, 27);
            dtpNgaySinh.TabIndex = 2;
            //
            // chkNhanEmail
            //
            chkNhanEmail.AutoSize = true;
            chkNhanEmail.Location = new Point(160, 148);
            chkNhanEmail.Name = "chkNhanEmail";
            chkNhanEmail.TabIndex = 3;
            chkNhanEmail.Text = "Nhận email thông báo";
            chkNhanEmail.UseVisualStyleBackColor = true;
            //
            // grpKhoaHoc
            //
            grpKhoaHoc.Controls.Add(lblKhoaHoc);
            grpKhoaHoc.Controls.Add(cboKhoaHoc);
            grpKhoaHoc.Controls.Add(lblHinhThuc);
            grpKhoaHoc.Controls.Add(radOnline);
            grpKhoaHoc.Controls.Add(radOffline);
            grpKhoaHoc.Controls.Add(lblSoThang);
            grpKhoaHoc.Controls.Add(numSoThang);
            grpKhoaHoc.Controls.Add(lblNhanTongTien);
            grpKhoaHoc.Controls.Add(lblTongTien);
            grpKhoaHoc.Location = new Point(15, 212);
            grpKhoaHoc.Name = "grpKhoaHoc";
            grpKhoaHoc.Size = new Size(555, 205);
            grpKhoaHoc.TabIndex = 1;
            grpKhoaHoc.TabStop = false;
            grpKhoaHoc.Text = "Thông tin khóa học";
            //
            // lblKhoaHoc
            //
            lblKhoaHoc.AutoSize = true;
            lblKhoaHoc.Location = new Point(20, 38);
            lblKhoaHoc.Name = "lblKhoaHoc";
            lblKhoaHoc.Text = "Khóa học:";
            //
            // cboKhoaHoc
            //
            cboKhoaHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoaHoc.FormattingEnabled = true;
            cboKhoaHoc.Location = new Point(160, 35);
            cboKhoaHoc.Name = "cboKhoaHoc";
            cboKhoaHoc.Size = new Size(370, 28);
            cboKhoaHoc.TabIndex = 0;
            cboKhoaHoc.SelectedIndexChanged += cboKhoaHoc_SelectedIndexChanged;
            //
            // lblHinhThuc
            //
            lblHinhThuc.AutoSize = true;
            lblHinhThuc.Location = new Point(20, 79);
            lblHinhThuc.Name = "lblHinhThuc";
            lblHinhThuc.Text = "Hình thức học:";
            //
            // radOnline
            //
            radOnline.AutoSize = true;
            radOnline.Location = new Point(160, 77);
            radOnline.Name = "radOnline";
            radOnline.TabIndex = 1;
            radOnline.TabStop = true;
            radOnline.Text = "Online";
            radOnline.UseVisualStyleBackColor = true;
            //
            // radOffline
            //
            radOffline.AutoSize = true;
            radOffline.Location = new Point(290, 77);
            radOffline.Name = "radOffline";
            radOffline.TabIndex = 2;
            radOffline.Text = "Trực tiếp";
            radOffline.UseVisualStyleBackColor = true;
            //
            // lblSoThang
            //
            lblSoThang.AutoSize = true;
            lblSoThang.Location = new Point(20, 120);
            lblSoThang.Name = "lblSoThang";
            lblSoThang.Text = "Số tháng đăng ký:";
            //
            // numSoThang
            //
            numSoThang.Location = new Point(160, 117);
            numSoThang.Maximum = new decimal(new int[] { 12, 0, 0, 0 });
            numSoThang.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numSoThang.Name = "numSoThang";
            numSoThang.Size = new Size(90, 27);
            numSoThang.TabIndex = 3;
            numSoThang.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numSoThang.ValueChanged += numSoThang_ValueChanged;
            //
            // lblNhanTongTien
            //
            lblNhanTongTien.AutoSize = true;
            lblNhanTongTien.Location = new Point(20, 163);
            lblNhanTongTien.Name = "lblNhanTongTien";
            lblNhanTongTien.Text = "Tổng học phí:";
            //
            // lblTongTien
            //
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.DarkGreen;
            lblTongTien.Location = new Point(160, 159);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Text = "0 VNĐ";
            //
            // btnDangKy
            //
            btnDangKy.Location = new Point(210, 435);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(110, 36);
            btnDangKy.TabIndex = 2;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = true;
            btnDangKy.Click += btnDangKy_Click;
            //
            // btnLamMoi
            //
            btnLamMoi.Location = new Point(335, 435);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(110, 36);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            //
            // btnThoat
            //
            btnThoat.Location = new Point(460, 435);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(110, 36);
            btnThoat.TabIndex = 4;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            //
            // FrmDangKyKhoaHoc
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(585, 490);
            Controls.Add(grpHocVien);
            Controls.Add(grpKhoaHoc);
            Controls.Add(btnDangKy);
            Controls.Add(btnLamMoi);
            Controls.Add(btnThoat);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "FrmDangKyKhoaHoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ĐĂNG KÝ KHÓA HỌC";
            Load += FrmDangKyKhoaHoc_Load;
            grpHocVien.ResumeLayout(false);
            grpHocVien.PerformLayout();
            grpKhoaHoc.ResumeLayout(false);
            grpKhoaHoc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox grpHocVien;
        private Label lblHoTen;
        private TextBox txtHoTen;
        private Label lblSoDienThoai;
        private TextBox txtSoDienThoai;
        private Label lblNgaySinh;
        private DateTimePicker dtpNgaySinh;
        private CheckBox chkNhanEmail;
        private GroupBox grpKhoaHoc;
        private Label lblKhoaHoc;
        private ComboBox cboKhoaHoc;
        private Label lblHinhThuc;
        private RadioButton radOnline;
        private RadioButton radOffline;
        private Label lblSoThang;
        private NumericUpDown numSoThang;
        private Label lblNhanTongTien;
        private Label lblTongTien;
        private Button btnDangKy;
        private Button btnLamMoi;
        private Button btnThoat;
    }
}

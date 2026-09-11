namespace Lab01_Ungdungthongtincanhan
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblHoTen = new Label();
            lblNamSinh = new Label();
            txtHoTen = new TextBox();
            txtNamSinh = new TextBox();
            grpGioitinh = new GroupBox();
            radNu = new RadioButton();
            radNam = new RadioButton();
            lblEmail = new Label();
            cboKhoa = new ComboBox();
            btnHienThi = new Button();
            btnXoa = new Button();
            btnThoat = new Button();
            txtEmail = new TextBox();
            lblKhoa = new Label();
            grpGioitinh.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.LightGoldenrodYellow;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.Black;
            lblTitle.ImageAlign = ContentAlignment.TopCenter;
            lblTitle.Location = new Point(15, 11);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(625, 44);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "THÔNG TIN CÁ NHÂN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Click += lblTitle_Click;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHoTen.Location = new Point(38, 100);
            lblHoTen.Margin = new Padding(4, 0, 4, 0);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(73, 25);
            lblHoTen.TabIndex = 1;
            lblHoTen.Text = "Họ tên:";
            // 
            // lblNamSinh
            // 
            lblNamSinh.AutoSize = true;
            lblNamSinh.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblNamSinh.Location = new Point(38, 150);
            lblNamSinh.Margin = new Padding(4, 0, 4, 0);
            lblNamSinh.Name = "lblNamSinh";
            lblNamSinh.Size = new Size(94, 25);
            lblNamSinh.TabIndex = 2;
            lblNamSinh.Text = "Năm sinh:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(200, 96);
            txtHoTen.Margin = new Padding(4);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(374, 31);
            txtHoTen.TabIndex = 3;
            // 
            // txtNamSinh
            // 
            txtNamSinh.Location = new Point(200, 146);
            txtNamSinh.Margin = new Padding(4);
            txtNamSinh.Name = "txtNamSinh";
            txtNamSinh.Size = new Size(186, 31);
            txtNamSinh.TabIndex = 4;
            // 
            // grpGioitinh
            // 
            grpGioitinh.Controls.Add(radNu);
            grpGioitinh.Controls.Add(radNam);
            grpGioitinh.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            grpGioitinh.Location = new Point(38, 244);
            grpGioitinh.Margin = new Padding(4);
            grpGioitinh.Name = "grpGioitinh";
            grpGioitinh.Padding = new Padding(4);
            grpGioitinh.Size = new Size(538, 62);
            grpGioitinh.TabIndex = 5;
            grpGioitinh.TabStop = false;
            grpGioitinh.Text = "Giới tính";
            // 
            // radNu
            // 
            radNu.AutoSize = true;
            radNu.Location = new Point(150, 25);
            radNu.Margin = new Padding(4);
            radNu.Name = "radNu";
            radNu.Size = new Size(62, 29);
            radNu.TabIndex = 1;
            radNu.TabStop = true;
            radNu.Text = "Nữ";
            radNu.UseVisualStyleBackColor = true;
            // 
            // radNam
            // 
            radNam.AutoSize = true;
            radNam.Location = new Point(25, 25);
            radNam.Margin = new Padding(4);
            radNam.Name = "radNam";
            radNam.Size = new Size(76, 29);
            radNam.TabIndex = 0;
            radNam.TabStop = true;
            radNam.Text = "Nam";
            radNam.UseVisualStyleBackColor = true;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(38, 192);
            lblEmail.Margin = new Padding(4, 0, 4, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(60, 25);
            lblEmail.TabIndex = 6;
            lblEmail.Text = "Email:";
            // 
            // cboKhoa
            // 
            cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Items.AddRange(new object[] { "Sư phạm Tin học", "Công nghệ Thông tin", "Giáo Dục Tiểu Học", "Giáo dục Mầm non" });
            cboKhoa.Location = new Point(200, 319);
            cboKhoa.Margin = new Padding(4);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(374, 33);
            cboKhoa.TabIndex = 7;
            // 
            // btnHienThi
            // 
            btnHienThi.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHienThi.Location = new Point(38, 375);
            btnHienThi.Margin = new Padding(4);
            btnHienThi.Name = "btnHienThi";
            btnHienThi.Size = new Size(150, 50);
            btnHienThi.TabIndex = 8;
            btnHienThi.Text = "Hiển thị";
            btnHienThi.UseVisualStyleBackColor = true;
            btnHienThi.Click += btnHienThi_Click;
            // 
            // btnXoa
            // 
            btnXoa.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.Location = new Point(212, 375);
            btnXoa.Margin = new Padding(4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(150, 50);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThoat.Location = new Point(388, 375);
            btnThoat.Margin = new Padding(4);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(188, 50);
            btnThoat.TabIndex = 10;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            btnThoat.Click += btnThoat_Click;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(200, 196);
            txtEmail.Margin = new Padding(4);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(374, 31);
            txtEmail.TabIndex = 11;
            // 
            // lblKhoa
            // 
            lblKhoa.AutoSize = true;
            lblKhoa.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKhoa.Location = new Point(38, 322);
            lblKhoa.Margin = new Padding(4, 0, 4, 0);
            lblKhoa.Name = "lblKhoa";
            lblKhoa.Size = new Size(95, 25);
            lblKhoa.TabIndex = 12;
            lblKhoa.Text = "Khoa/Lớp:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(665, 441);
            Controls.Add(lblKhoa);
            Controls.Add(txtEmail);
            Controls.Add(btnThoat);
            Controls.Add(btnXoa);
            Controls.Add(btnHienThi);
            Controls.Add(cboKhoa);
            Controls.Add(lblEmail);
            Controls.Add(grpGioitinh);
            Controls.Add(txtNamSinh);
            Controls.Add(txtHoTen);
            Controls.Add(lblNamSinh);
            Controls.Add(lblHoTen);
            Controls.Add(lblTitle);
            ForeColor = SystemColors.Desktop;
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Lab 01 - Ứng dụng thông tin cá nhân";
            Load += Form1_Load;
            grpGioitinh.ResumeLayout(false);
            grpGioitinh.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblHoTen;
        private Label lblNamSinh;
        private TextBox txtHoTen;
        private TextBox txtNamSinh;
        private GroupBox grpGioitinh;
        private RadioButton radNu;
        private RadioButton radNam;
        private Label lblEmail;
        private ComboBox cboKhoa;
        private Button btnHienThi;
        private Button btnXoa;
        private Button btnThoat;
        private TextBox txtEmail;
        private Label lblKhoa;
    }
}

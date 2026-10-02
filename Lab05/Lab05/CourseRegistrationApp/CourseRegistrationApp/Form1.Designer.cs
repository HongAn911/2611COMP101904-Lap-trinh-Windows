namespace CourseRegistrationApp
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
            groupBox1 = new GroupBox();
            label4 = new Label();
            dtpNgaySinh = new DateTimePicker();
            chkNhanEmail = new CheckBox();
            label3 = new Label();
            txtSoDienThoai = new TextBox();
            label2 = new Label();
            txtHoTen = new TextBox();
            label1 = new Label();
            groupBox2 = new GroupBox();
            radOffline = new RadioButton();
            radOnline = new RadioButton();
            label8 = new Label();
            lblTongTien = new Label();
            label7 = new Label();
            numSoThang = new NumericUpDown();
            label6 = new Label();
            cboKhoaHoc = new ComboBox();
            label5 = new Label();
            btnDangKy = new Button();
            btnLamMoi = new Button();
            btnThoat = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = SystemColors.ButtonFace;
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(dtpNgaySinh);
            groupBox1.Controls.Add(chkNhanEmail);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtSoDienThoai);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtHoTen);
            groupBox1.Controls.Add(label1);
            groupBox1.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            groupBox1.Location = new Point(27, 21);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(442, 195);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "THÔNG TIN HỌC VIÊN";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(26, 116);
            label4.Name = "label4";
            label4.Size = new Size(81, 19);
            label4.TabIndex = 7;
            label4.Text = "Ngày sinh:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Location = new Point(155, 111);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(237, 27);
            dtpNgaySinh.TabIndex = 6;
            // 
            // chkNhanEmail
            // 
            chkNhanEmail.AutoSize = true;
            chkNhanEmail.Location = new Point(26, 159);
            chkNhanEmail.Name = "chkNhanEmail";
            chkNhanEmail.Size = new Size(178, 23);
            chkNhanEmail.TabIndex = 5;
            chkNhanEmail.Text = "Nhận email thông báo";
            chkNhanEmail.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(26, 94);
            label3.Name = "label3";
            label3.Size = new Size(0, 19);
            label3.TabIndex = 4;
            label3.Click += label3_Click;
            // 
            // txtSoDienThoai
            // 
            txtSoDienThoai.Location = new Point(155, 66);
            txtSoDienThoai.Name = "txtSoDienThoai";
            txtSoDienThoai.Size = new Size(237, 27);
            txtSoDienThoai.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 73);
            label2.Name = "label2";
            label2.Size = new Size(104, 19);
            label2.TabIndex = 2;
            label2.Text = "Số điện thoại:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(155, 25);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(237, 27);
            txtHoTen.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 32);
            label1.Name = "label1";
            label1.Size = new Size(60, 19);
            label1.TabIndex = 0;
            label1.Text = "Họ tên:";
            label1.Click += label1_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = SystemColors.ButtonFace;
            groupBox2.Controls.Add(radOffline);
            groupBox2.Controls.Add(radOnline);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(lblTongTien);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(numSoThang);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(cboKhoaHoc);
            groupBox2.Controls.Add(label5);
            groupBox2.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            groupBox2.Location = new Point(27, 235);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(442, 203);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "THÔNG TIN KHÓA HỌC";
            // 
            // radOffline
            // 
            radOffline.AutoSize = true;
            radOffline.Location = new Point(260, 74);
            radOffline.Name = "radOffline";
            radOffline.Size = new Size(91, 23);
            radOffline.TabIndex = 8;
            radOffline.TabStop = true;
            radOffline.Text = "Trực tiếp";
            radOffline.UseVisualStyleBackColor = true;
            radOffline.CheckedChanged += radOffline_CheckedChanged;
            // 
            // radOnline
            // 
            radOnline.AutoSize = true;
            radOnline.Location = new Point(155, 76);
            radOnline.Name = "radOnline";
            radOnline.Size = new Size(76, 23);
            radOnline.TabIndex = 7;
            radOnline.TabStop = true;
            radOnline.Text = "Online";
            radOnline.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(19, 78);
            label8.Name = "label8";
            label8.Size = new Size(110, 19);
            label8.TabIndex = 6;
            label8.Text = "Hình thức học:";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Location = new Point(154, 161);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(57, 19);
            lblTongTien.TabIndex = 5;
            lblTongTien.Text = "0 VND";
            lblTongTien.Click += lblTongTien_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 161);
            label7.Name = "label7";
            label7.Size = new Size(102, 19);
            label7.TabIndex = 4;
            label7.Text = "Tổng học phí:";
            // 
            // numSoThang
            // 
            numSoThang.Location = new Point(155, 115);
            numSoThang.Name = "numSoThang";
            numSoThang.Size = new Size(150, 27);
            numSoThang.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 121);
            label6.Name = "label6";
            label6.Size = new Size(128, 19);
            label6.TabIndex = 2;
            label6.Text = "Số tháng đăng ký:";
            // 
            // cboKhoaHoc
            // 
            cboKhoaHoc.FormattingEnabled = true;
            cboKhoaHoc.Location = new Point(155, 25);
            cboKhoaHoc.Name = "cboKhoaHoc";
            cboKhoaHoc.Size = new Size(151, 27);
            cboKhoaHoc.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 33);
            label5.Name = "label5";
            label5.Size = new Size(79, 19);
            label5.TabIndex = 0;
            label5.Text = "Khóa học:";
            // 
            // btnDangKy
            // 
            btnDangKy.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnDangKy.Location = new Point(100, 459);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(94, 29);
            btnDangKy.TabIndex = 2;
            btnDangKy.Text = "Đăng ký";
            btnDangKy.UseVisualStyleBackColor = true;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnLamMoi.Location = new Point(238, 459);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(94, 29);
            btnLamMoi.TabIndex = 3;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            // 
            // btnThoat
            // 
            btnThoat.Font = new Font("Times New Roman", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnThoat.Location = new Point(375, 459);
            btnThoat.Name = "btnThoat";
            btnThoat.Size = new Size(94, 29);
            btnThoat.TabIndex = 4;
            btnThoat.Text = "Thoát";
            btnThoat.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(502, 513);
            Controls.Add(btnThoat);
            Controls.Add(btnLamMoi);
            Controls.Add(btnDangKy);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "ĐĂNG KÝ KHÓA HỌC";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numSoThang).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label2;
        private TextBox txtHoTen;
        private Label label1;
        private GroupBox groupBox2;
        private Label label3;
        private TextBox txtSoDienThoai;
        private Label label4;
        private DateTimePicker dtpNgaySinh;
        private CheckBox chkNhanEmail;
        private ComboBox cboKhoaHoc;
        private Label label5;
        private Label lblTongTien;
        private Label label7;
        private NumericUpDown numSoThang;
        private Label label6;
        private Button btnDangKy;
        private Button btnLamMoi;
        private Button btnThoat;
        private RadioButton radOffline;
        private RadioButton radOnline;
        private Label label8;
    }
}

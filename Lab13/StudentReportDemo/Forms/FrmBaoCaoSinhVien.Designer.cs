namespace StudentReportDemo.Forms
{
    partial class FrmBaoCaoSinhVien
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlDieuKien = new Panel();
            lblTieuDe = new Label();
            lblLop = new Label();
            cboLop = new ComboBox();
            lblKetQua = new Label();
            cboKetQua = new ComboBox();
            lblTuKhoa = new Label();
            txtTuKhoa = new TextBox();
            btnXemBaoCao = new Button();
            btnThongKe = new Button();
            btnXuatFile = new Button();
            lblSapXep = new Label();
            cboSapXep = new ComboBox();
            dgvBaoCao = new DataGridView();
            stsThongKe = new StatusStrip();
            lblThongKe = new ToolStripStatusLabel();
            pnlDieuKien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).BeginInit();
            stsThongKe.SuspendLayout();
            SuspendLayout();
            //
            // pnlDieuKien
            //
            pnlDieuKien.Controls.Add(lblTieuDe);
            pnlDieuKien.Controls.Add(lblLop);
            pnlDieuKien.Controls.Add(cboLop);
            pnlDieuKien.Controls.Add(lblKetQua);
            pnlDieuKien.Controls.Add(cboKetQua);
            pnlDieuKien.Controls.Add(lblTuKhoa);
            pnlDieuKien.Controls.Add(txtTuKhoa);
            pnlDieuKien.Controls.Add(btnXemBaoCao);
            pnlDieuKien.Controls.Add(btnThongKe);
            pnlDieuKien.Controls.Add(btnXuatFile);
            pnlDieuKien.Controls.Add(lblSapXep);
            pnlDieuKien.Controls.Add(cboSapXep);
            pnlDieuKien.Dock = DockStyle.Top;
            pnlDieuKien.Location = new Point(0, 0);
            pnlDieuKien.Name = "pnlDieuKien";
            pnlDieuKien.Padding = new Padding(12);
            pnlDieuKien.Size = new Size(884, 140);
            pnlDieuKien.TabIndex = 0;
            //
            // lblTieuDe
            //
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(0, 84, 147);
            lblTieuDe.Location = new Point(12, 10);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(340, 25);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "BÁO CÁO DANH SÁCH SINH VIÊN";
            //
            // lblLop
            //
            lblLop.AutoSize = true;
            lblLop.Location = new Point(14, 55);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(30, 15);
            lblLop.TabIndex = 1;
            lblLop.Text = "Lớp:";
            //
            // cboLop
            //
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.Location = new Point(80, 51);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(170, 23);
            cboLop.TabIndex = 2;
            cboLop.SelectedIndexChanged += cboLop_SelectedIndexChanged;
            //
            // lblKetQua
            //
            lblKetQua.AutoSize = true;
            lblKetQua.Location = new Point(275, 55);
            lblKetQua.Name = "lblKetQua";
            lblKetQua.Size = new Size(50, 15);
            lblKetQua.TabIndex = 3;
            lblKetQua.Text = "Kết quả:";
            //
            // cboKetQua
            //
            cboKetQua.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKetQua.Location = new Point(340, 51);
            cboKetQua.Name = "cboKetQua";
            cboKetQua.Size = new Size(130, 23);
            cboKetQua.TabIndex = 4;
            cboKetQua.SelectedIndexChanged += cboKetQua_SelectedIndexChanged;
            //
            // lblTuKhoa
            //
            lblTuKhoa.AutoSize = true;
            lblTuKhoa.Location = new Point(495, 55);
            lblTuKhoa.Name = "lblTuKhoa";
            lblTuKhoa.Size = new Size(53, 15);
            lblTuKhoa.TabIndex = 5;
            lblTuKhoa.Text = "Từ khóa:";
            //
            // txtTuKhoa
            //
            txtTuKhoa.Location = new Point(560, 51);
            txtTuKhoa.Name = "txtTuKhoa";
            txtTuKhoa.PlaceholderText = "Nhập mã SV hoặc họ tên...";
            txtTuKhoa.Size = new Size(300, 23);
            txtTuKhoa.TabIndex = 6;
            txtTuKhoa.TextChanged += txtTuKhoa_TextChanged;
            //
            // btnXemBaoCao
            //
            btnXemBaoCao.Location = new Point(80, 92);
            btnXemBaoCao.Name = "btnXemBaoCao";
            btnXemBaoCao.Size = new Size(130, 32);
            btnXemBaoCao.TabIndex = 7;
            btnXemBaoCao.Text = "Xem báo cáo";
            btnXemBaoCao.UseVisualStyleBackColor = true;
            btnXemBaoCao.Click += btnXemBaoCao_Click;
            //
            // btnThongKe
            //
            btnThongKe.Location = new Point(222, 92);
            btnThongKe.Name = "btnThongKe";
            btnThongKe.Size = new Size(130, 32);
            btnThongKe.TabIndex = 8;
            btnThongKe.Text = "Thống kê theo lớp";
            btnThongKe.UseVisualStyleBackColor = true;
            btnThongKe.Click += btnThongKe_Click;
            //
            // btnXuatFile
            //
            btnXuatFile.Location = new Point(364, 92);
            btnXuatFile.Name = "btnXuatFile";
            btnXuatFile.Size = new Size(130, 32);
            btnXuatFile.TabIndex = 9;
            btnXuatFile.Text = "Xuất file";
            btnXuatFile.UseVisualStyleBackColor = true;
            btnXuatFile.Click += btnXuatFile_Click;
            // lblSapXep
            lblSapXep.AutoSize = true;
            lblSapXep.Location = new Point(515, 101);
            lblSapXep.Name = "lblSapXep";
            lblSapXep.Size = new Size(53, 15);
            lblSapXep.TabIndex = 12;
            lblSapXep.Text = "Sắp xếp:";
            // cboSapXep
            cboSapXep.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSapXep.Location = new Point(580, 97);
            cboSapXep.Name = "cboSapXep";
            cboSapXep.Size = new Size(170, 23);
            cboSapXep.TabIndex = 13;
            cboSapXep.SelectedIndexChanged += cboSapXep_SelectedIndexChanged;
            //
            // dgvBaoCao
            //
            dgvBaoCao.AllowUserToAddRows = false;
            dgvBaoCao.AllowUserToDeleteRows = false;
            dgvBaoCao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBaoCao.BackgroundColor = Color.White;
            dgvBaoCao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBaoCao.Dock = DockStyle.Fill;
            dgvBaoCao.Location = new Point(0, 140);
            dgvBaoCao.MultiSelect = false;
            dgvBaoCao.Name = "dgvBaoCao";
            dgvBaoCao.ReadOnly = true;
            dgvBaoCao.RowHeadersVisible = false;
            dgvBaoCao.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBaoCao.Size = new Size(884, 399);
            dgvBaoCao.TabIndex = 10;
            //
            // stsThongKe
            //
            stsThongKe.Items.AddRange(new ToolStripItem[] { lblThongKe });
            stsThongKe.Location = new Point(0, 539);
            stsThongKe.Name = "stsThongKe";
            stsThongKe.Size = new Size(884, 22);
            stsThongKe.TabIndex = 11;
            //
            // lblThongKe
            //
            lblThongKe.Name = "lblThongKe";
            lblThongKe.Size = new Size(60, 17);
            lblThongKe.Text = "Sẵn sàng";
            //
            // FrmBaoCaoSinhVien
            //
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(dgvBaoCao);
            Controls.Add(pnlDieuKien);
            Controls.Add(stsThongKe);
            MinimumSize = new Size(900, 600);
            Name = "FrmBaoCaoSinhVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Lab 13 - Báo cáo sinh viên bằng LINQ";
            Load += FrmBaoCaoSinhVien_Load;
            pnlDieuKien.ResumeLayout(false);
            pnlDieuKien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBaoCao).EndInit();
            stsThongKe.ResumeLayout(false);
            stsThongKe.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlDieuKien;
        private Label lblTieuDe;
        private Label lblLop;
        private ComboBox cboLop;
        private Label lblKetQua;
        private ComboBox cboKetQua;
        private Label lblTuKhoa;
        private TextBox txtTuKhoa;
        private Button btnXemBaoCao;
        private Button btnThongKe;
        private Button btnXuatFile;
        private Label lblSapXep;
        private ComboBox cboSapXep;
        private DataGridView dgvBaoCao;
        private StatusStrip stsThongKe;
        private ToolStripStatusLabel lblThongKe;
    }
}

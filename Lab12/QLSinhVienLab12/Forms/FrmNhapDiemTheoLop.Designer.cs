namespace QLSinhVienLab12.Forms
{
    partial class FrmNhapDiemTheoLop
    {
        private System.ComponentModel.IContainer components = null;

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
            lblTieuDe = new Label();
            lblLop = new Label();
            cboLop = new ComboBox();
            lblMonHoc = new Label();
            cboMonHoc = new ComboBox();
            btnTaiDanhSach = new Button();
            lblTim = new Label();
            txtTim = new TextBox();
            dgvKetQua = new DataGridView();
            colMaSV = new DataGridViewTextBoxColumn();
            colHoTen = new DataGridViewTextBoxColumn();
            colDiem = new DataGridViewTextBoxColumn();
            colGhiChu = new DataGridViewTextBoxColumn();
            lblThongKe = new Label();
            btnLuuTatCa = new Button();
            statusStrip1 = new StatusStrip();
            tsslTrangThai = new ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lblTieuDe
            // 
            lblTieuDe.AutoSize = true;
            lblTieuDe.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            lblTieuDe.ForeColor = Color.FromArgb(0, 70, 140);
            lblTieuDe.Location = new Point(16, 12);
            lblTieuDe.Name = "lblTieuDe";
            lblTieuDe.Size = new Size(260, 28);
            lblTieuDe.TabIndex = 0;
            lblTieuDe.Text = "NHẬP ĐIỂM THEO LỚP";
            // 
            // lblLop
            // 
            lblLop.AutoSize = true;
            lblLop.Location = new Point(18, 62);
            lblLop.Name = "lblLop";
            lblLop.Size = new Size(27, 15);
            lblLop.TabIndex = 1;
            lblLop.Text = "Lớp:";
            // 
            // cboLop
            // 
            cboLop.DropDownStyle = ComboBoxStyle.DropDownList;
            cboLop.FormattingEnabled = true;
            cboLop.Location = new Point(80, 58);
            cboLop.Name = "cboLop";
            cboLop.Size = new Size(230, 23);
            cboLop.TabIndex = 1;
            cboLop.SelectionChangeCommitted += CboLopMon_SelectionChangeCommitted;
            // 
            // lblMonHoc
            // 
            lblMonHoc.AutoSize = true;
            lblMonHoc.Location = new Point(330, 62);
            lblMonHoc.Name = "lblMonHoc";
            lblMonHoc.Size = new Size(54, 15);
            lblMonHoc.TabIndex = 3;
            lblMonHoc.Text = "Môn học:";
            // 
            // cboMonHoc
            // 
            cboMonHoc.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMonHoc.FormattingEnabled = true;
            cboMonHoc.Location = new Point(395, 58);
            cboMonHoc.Name = "cboMonHoc";
            cboMonHoc.Size = new Size(240, 23);
            cboMonHoc.TabIndex = 2;
            cboMonHoc.SelectionChangeCommitted += CboLopMon_SelectionChangeCommitted;
            // 
            // btnTaiDanhSach
            // 
            btnTaiDanhSach.BackColor = Color.FromArgb(0, 102, 204);
            btnTaiDanhSach.FlatStyle = FlatStyle.Flat;
            btnTaiDanhSach.ForeColor = Color.White;
            btnTaiDanhSach.Location = new Point(655, 55);
            btnTaiDanhSach.Name = "btnTaiDanhSach";
            btnTaiDanhSach.Size = new Size(130, 29);
            btnTaiDanhSach.TabIndex = 3;
            btnTaiDanhSach.Text = "Tải danh sách";
            btnTaiDanhSach.UseVisualStyleBackColor = false;
            btnTaiDanhSach.Click += btnTaiDanhSach_Click;
            // 
            // lblTim
            // 
            lblTim.AutoSize = true;
            lblTim.Location = new Point(18, 102);
            lblTim.Name = "lblTim";
            lblTim.Size = new Size(55, 15);
            lblTim.TabIndex = 6;
            lblTim.Text = "Tìm kiếm:";
            // 
            // txtTim
            // 
            txtTim.Enabled = false;
            txtTim.Location = new Point(80, 98);
            txtTim.Name = "txtTim";
            txtTim.PlaceholderText = "Nhập mã SV hoặc họ tên để lọc...";
            txtTim.Size = new Size(230, 23);
            txtTim.TabIndex = 4;
            txtTim.TextChanged += txtTim_TextChanged;
            // 
            // dgvKetQua
            // 
            dgvKetQua.AllowUserToAddRows = false;
            dgvKetQua.AllowUserToDeleteRows = false;
            dgvKetQua.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKetQua.AutoGenerateColumns = false;
            dgvKetQua.BackgroundColor = SystemColors.Window;
            dgvKetQua.Columns.AddRange(new DataGridViewColumn[] { colMaSV, colHoTen, colDiem, colGhiChu });
            dgvKetQua.Location = new Point(16, 135);
            dgvKetQua.MultiSelect = false;
            dgvKetQua.Name = "dgvKetQua";
            dgvKetQua.RowHeadersWidth = 28;
            dgvKetQua.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKetQua.Size = new Size(769, 330);
            dgvKetQua.TabIndex = 5;
            dgvKetQua.CellEndEdit += dgvKetQua_CellEndEdit;
            dgvKetQua.CellParsing += dgvKetQua_CellParsing;
            dgvKetQua.CellValidating += dgvKetQua_CellValidating;
            dgvKetQua.DataError += dgvKetQua_DataError;
            // 
            // colMaSV
            // 
            colMaSV.DataPropertyName = "MaSV";
            colMaSV.FillWeight = 18F;
            colMaSV.HeaderText = "Mã SV";
            colMaSV.Name = "colMaSV";
            colMaSV.ReadOnly = true;
            // 
            // colHoTen
            // 
            colHoTen.DataPropertyName = "HoTen";
            colHoTen.FillWeight = 36F;
            colHoTen.HeaderText = "Họ tên";
            colHoTen.Name = "colHoTen";
            colHoTen.ReadOnly = true;
            // 
            // colDiem
            // 
            colDiem.DataPropertyName = "Diem";
            colDiem.DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, BackColor = Color.FromArgb(255, 252, 230) };
            colDiem.FillWeight = 14F;
            colDiem.HeaderText = "Điểm";
            colDiem.Name = "colDiem";
            // 
            // colGhiChu
            // 
            colGhiChu.DataPropertyName = "GhiChu";
            colGhiChu.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(255, 252, 230) };
            colGhiChu.FillWeight = 32F;
            colGhiChu.HeaderText = "Ghi chú";
            colGhiChu.Name = "colGhiChu";
            // 
            // lblThongKe
            // 
            lblThongKe.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblThongKe.AutoSize = true;
            lblThongKe.Location = new Point(16, 480);
            lblThongKe.Name = "lblThongKe";
            lblThongKe.Size = new Size(94, 15);
            lblThongKe.TabIndex = 8;
            lblThongKe.Text = "Thống kê: (chưa có dữ liệu)";
            // 
            // btnLuuTatCa
            // 
            btnLuuTatCa.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnLuuTatCa.BackColor = Color.FromArgb(0, 140, 70);
            btnLuuTatCa.Enabled = false;
            btnLuuTatCa.FlatStyle = FlatStyle.Flat;
            btnLuuTatCa.ForeColor = Color.White;
            btnLuuTatCa.Location = new Point(655, 474);
            btnLuuTatCa.Name = "btnLuuTatCa";
            btnLuuTatCa.Size = new Size(130, 30);
            btnLuuTatCa.TabIndex = 6;
            btnLuuTatCa.Text = "Lưu tất cả";
            btnLuuTatCa.UseVisualStyleBackColor = false;
            btnLuuTatCa.Click += btnLuuTatCa_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { tsslTrangThai });
            statusStrip1.Location = new Point(0, 518);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(804, 22);
            statusStrip1.TabIndex = 9;
            // 
            // tsslTrangThai
            // 
            tsslTrangThai.Name = "tsslTrangThai";
            tsslTrangThai.Size = new Size(39, 17);
            tsslTrangThai.Text = "Sẵn sàng";
            // 
            // FrmNhapDiemTheoLop
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(804, 540);
            Controls.Add(lblTieuDe);
            Controls.Add(lblLop);
            Controls.Add(cboLop);
            Controls.Add(lblMonHoc);
            Controls.Add(cboMonHoc);
            Controls.Add(btnTaiDanhSach);
            Controls.Add(lblTim);
            Controls.Add(txtTim);
            Controls.Add(dgvKetQua);
            Controls.Add(lblThongKe);
            Controls.Add(btnLuuTatCa);
            Controls.Add(statusStrip1);
            MinimumSize = new Size(820, 480);
            Name = "FrmNhapDiemTheoLop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý kết quả học tập - Nhập điểm theo lớp";
            Load += FrmNhapDiemTheoLop_Load;
            ((System.ComponentModel.ISupportInitialize)dgvKetQua).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTieuDe;
        private Label lblLop;
        private ComboBox cboLop;
        private Label lblMonHoc;
        private ComboBox cboMonHoc;
        private Button btnTaiDanhSach;
        private Label lblTim;
        private TextBox txtTim;
        private DataGridView dgvKetQua;
        private DataGridViewTextBoxColumn colMaSV;
        private DataGridViewTextBoxColumn colHoTen;
        private DataGridViewTextBoxColumn colDiem;
        private DataGridViewTextBoxColumn colGhiChu;
        private Label lblThongKe;
        private Button btnLuuTatCa;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel tsslTrangThai;
    }
}

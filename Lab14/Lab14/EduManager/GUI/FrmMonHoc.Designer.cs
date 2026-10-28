namespace EduManager.GUI
{
    partial class FrmMonHoc
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer? components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            DataGridViewCellStyle styleHeader = new DataGridViewCellStyle();
            DataGridViewCellStyle styleCell = new DataGridViewCellStyle();
            DataGridViewCellStyle styleAlt = new DataGridViewCellStyle();
            DataGridViewCellStyle styleCenter = new DataGridViewCellStyle();
            pnlHeader = new Panel();
            lblSubTitle = new Label();
            lblTitle = new Label();
            pnlThongTin = new Panel();
            lblGhiChu = new Label();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            pnlLine = new Panel();
            chkTrangThai = new CheckBox();
            pnlSoTinChi = new Panel();
            nudSoTinChi = new NumericUpDown();
            lblSoTinChi = new Label();
            pnlTenMonHoc = new Panel();
            txtTenMonHoc = new TextBox();
            lblTenMonHoc = new Label();
            pnlMaMonHoc = new Panel();
            txtMaMonHoc = new TextBox();
            lblMaMonHoc = new Label();
            lblCheDo = new Label();
            lblHeaderThongTin = new Label();
            pnlDanhSach = new Panel();
            dgvMonHoc = new DataGridView();
            colMaMonHoc = new DataGridViewTextBoxColumn();
            colTenMonHoc = new DataGridViewTextBoxColumn();
            colSoTinChi = new DataGridViewTextBoxColumn();
            colTrangThai = new DataGridViewCheckBoxColumn();
            btnTimKiem = new Button();
            pnlTimKiem = new Panel();
            txtTimKiem = new TextBox();
            lblHeaderDanhSach = new Label();
            ssTrangThai = new StatusStrip();
            lblTrangThai = new ToolStripStatusLabel();
            lblTongSo = new ToolStripStatusLabel();
            pnlHeader.SuspendLayout();
            pnlThongTin.SuspendLayout();
            pnlSoTinChi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSoTinChi).BeginInit();
            pnlTenMonHoc.SuspendLayout();
            pnlMaMonHoc.SuspendLayout();
            pnlDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).BeginInit();
            pnlTimKiem.SuspendLayout();
            ssTrangThai.SuspendLayout();
            SuspendLayout();
            //
            // pnlHeader
            //
            pnlHeader.BackColor = Color.FromArgb(30, 64, 175);
            pnlHeader.Controls.Add(lblSubTitle);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 78);
            pnlHeader.TabIndex = 0;
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(22, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "QUẢN LÝ MÔN HỌC";
            //
            // lblSubTitle
            //
            lblSubTitle.AutoSize = true;
            lblSubTitle.Font = new Font("Segoe UI", 9.75F);
            lblSubTitle.ForeColor = Color.FromArgb(191, 219, 254);
            lblSubTitle.Location = new Point(26, 48);
            lblSubTitle.Name = "lblSubTitle";
            lblSubTitle.Text = "EduManager  •  Entity Framework Core  •  Mô hình 3 lớp GUI – BLL – DAL";
            //
            // pnlThongTin
            //
            pnlThongTin.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pnlThongTin.BackColor = Color.White;
            pnlThongTin.Controls.Add(lblGhiChu);
            pnlThongTin.Controls.Add(btnLamMoi);
            pnlThongTin.Controls.Add(btnXoa);
            pnlThongTin.Controls.Add(btnSua);
            pnlThongTin.Controls.Add(btnThem);
            pnlThongTin.Controls.Add(pnlLine);
            pnlThongTin.Controls.Add(chkTrangThai);
            pnlThongTin.Controls.Add(pnlSoTinChi);
            pnlThongTin.Controls.Add(lblSoTinChi);
            pnlThongTin.Controls.Add(pnlTenMonHoc);
            pnlThongTin.Controls.Add(lblTenMonHoc);
            pnlThongTin.Controls.Add(pnlMaMonHoc);
            pnlThongTin.Controls.Add(lblMaMonHoc);
            pnlThongTin.Controls.Add(lblCheDo);
            pnlThongTin.Controls.Add(lblHeaderThongTin);
            pnlThongTin.Location = new Point(20, 94);
            pnlThongTin.Name = "pnlThongTin";
            pnlThongTin.Size = new Size(370, 544);
            pnlThongTin.TabIndex = 1;
            pnlThongTin.Paint += The_Paint;
            pnlThongTin.Resize += VeLai_Resize;
            //
            // lblHeaderThongTin
            //
            lblHeaderThongTin.AutoSize = true;
            lblHeaderThongTin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblHeaderThongTin.ForeColor = Color.FromArgb(30, 64, 175);
            lblHeaderThongTin.Location = new Point(18, 16);
            lblHeaderThongTin.Name = "lblHeaderThongTin";
            lblHeaderThongTin.Text = "THÔNG TIN MÔN HỌC";
            //
            // lblCheDo
            //
            lblCheDo.AutoSize = true;
            lblCheDo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCheDo.ForeColor = Color.FromArgb(22, 163, 74);
            lblCheDo.Location = new Point(20, 44);
            lblCheDo.Name = "lblCheDo";
            lblCheDo.Text = "●  Chế độ: Thêm mới";
            //
            // lblMaMonHoc
            //
            lblMaMonHoc.AutoSize = true;
            lblMaMonHoc.Font = new Font("Segoe UI Semibold", 9.75F);
            lblMaMonHoc.ForeColor = Color.FromArgb(71, 85, 105);
            lblMaMonHoc.Location = new Point(18, 78);
            lblMaMonHoc.Name = "lblMaMonHoc";
            lblMaMonHoc.Text = "Mã môn học *";
            //
            // pnlMaMonHoc
            //
            pnlMaMonHoc.BackColor = Color.White;
            pnlMaMonHoc.Controls.Add(txtMaMonHoc);
            pnlMaMonHoc.Location = new Point(20, 102);
            pnlMaMonHoc.Name = "pnlMaMonHoc";
            pnlMaMonHoc.Padding = new Padding(12, 9, 12, 6);
            pnlMaMonHoc.Size = new Size(330, 42);
            pnlMaMonHoc.Paint += KhungNhap_Paint;
            pnlMaMonHoc.Click += KhungNhap_Click;
            //
            // txtMaMonHoc
            //
            txtMaMonHoc.BackColor = Color.White;
            txtMaMonHoc.BorderStyle = BorderStyle.None;
            txtMaMonHoc.CharacterCasing = CharacterCasing.Upper;
            txtMaMonHoc.Dock = DockStyle.Fill;
            txtMaMonHoc.Font = new Font("Segoe UI", 11F);
            txtMaMonHoc.ForeColor = Color.FromArgb(15, 23, 42);
            txtMaMonHoc.MaxLength = 10;
            txtMaMonHoc.Name = "txtMaMonHoc";
            txtMaMonHoc.PlaceholderText = "VD: COMP1019";
            txtMaMonHoc.TabIndex = 0;
            txtMaMonHoc.Enter += O_DoiFocus;
            txtMaMonHoc.Leave += O_DoiFocus;
            //
            // lblTenMonHoc
            //
            lblTenMonHoc.AutoSize = true;
            lblTenMonHoc.Font = new Font("Segoe UI Semibold", 9.75F);
            lblTenMonHoc.ForeColor = Color.FromArgb(71, 85, 105);
            lblTenMonHoc.Location = new Point(18, 154);
            lblTenMonHoc.Name = "lblTenMonHoc";
            lblTenMonHoc.Text = "Tên môn học *";
            //
            // pnlTenMonHoc
            //
            pnlTenMonHoc.BackColor = Color.White;
            pnlTenMonHoc.Controls.Add(txtTenMonHoc);
            pnlTenMonHoc.Location = new Point(20, 178);
            pnlTenMonHoc.Name = "pnlTenMonHoc";
            pnlTenMonHoc.Padding = new Padding(12, 9, 12, 6);
            pnlTenMonHoc.Size = new Size(330, 42);
            pnlTenMonHoc.Paint += KhungNhap_Paint;
            pnlTenMonHoc.Click += KhungNhap_Click;
            //
            // txtTenMonHoc
            //
            txtTenMonHoc.BackColor = Color.White;
            txtTenMonHoc.BorderStyle = BorderStyle.None;
            txtTenMonHoc.Dock = DockStyle.Fill;
            txtTenMonHoc.Font = new Font("Segoe UI", 11F);
            txtTenMonHoc.ForeColor = Color.FromArgb(15, 23, 42);
            txtTenMonHoc.MaxLength = 100;
            txtTenMonHoc.Name = "txtTenMonHoc";
            txtTenMonHoc.PlaceholderText = "VD: Lập trình trên Windows";
            txtTenMonHoc.TabIndex = 1;
            txtTenMonHoc.Enter += O_DoiFocus;
            txtTenMonHoc.Leave += O_DoiFocus;
            //
            // lblSoTinChi
            //
            lblSoTinChi.AutoSize = true;
            lblSoTinChi.Font = new Font("Segoe UI Semibold", 9.75F);
            lblSoTinChi.ForeColor = Color.FromArgb(71, 85, 105);
            lblSoTinChi.Location = new Point(18, 230);
            lblSoTinChi.Name = "lblSoTinChi";
            lblSoTinChi.Text = "Số tín chỉ (1 - 6)";
            //
            // pnlSoTinChi
            //
            pnlSoTinChi.BackColor = Color.White;
            pnlSoTinChi.Controls.Add(nudSoTinChi);
            pnlSoTinChi.Location = new Point(20, 254);
            pnlSoTinChi.Name = "pnlSoTinChi";
            pnlSoTinChi.Padding = new Padding(10, 8, 4, 6);
            pnlSoTinChi.Size = new Size(130, 42);
            pnlSoTinChi.Paint += KhungNhap_Paint;
            pnlSoTinChi.Click += KhungNhap_Click;
            //
            // nudSoTinChi
            //
            nudSoTinChi.BackColor = Color.White;
            nudSoTinChi.BorderStyle = BorderStyle.None;
            nudSoTinChi.Dock = DockStyle.Fill;
            nudSoTinChi.Font = new Font("Segoe UI", 11F);
            nudSoTinChi.ForeColor = Color.FromArgb(15, 23, 42);
            nudSoTinChi.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            nudSoTinChi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoTinChi.Name = "nudSoTinChi";
            nudSoTinChi.TabIndex = 2;
            nudSoTinChi.TextAlign = HorizontalAlignment.Center;
            nudSoTinChi.Value = new decimal(new int[] { 3, 0, 0, 0 });
            nudSoTinChi.Enter += O_DoiFocus;
            nudSoTinChi.Leave += O_DoiFocus;
            //
            // chkTrangThai
            //
            chkTrangThai.AutoSize = true;
            chkTrangThai.Checked = true;
            chkTrangThai.CheckState = CheckState.Checked;
            chkTrangThai.Cursor = Cursors.Hand;
            chkTrangThai.ForeColor = Color.FromArgb(51, 65, 85);
            chkTrangThai.Location = new Point(176, 263);
            chkTrangThai.Name = "chkTrangThai";
            chkTrangThai.TabIndex = 3;
            chkTrangThai.Text = "Còn sử dụng";
            chkTrangThai.UseVisualStyleBackColor = true;
            //
            // pnlLine
            //
            pnlLine.BackColor = Color.FromArgb(226, 232, 240);
            pnlLine.Location = new Point(20, 314);
            pnlLine.Name = "pnlLine";
            pnlLine.Size = new Size(330, 1);
            //
            // btnThem
            //
            btnThem.BackColor = Color.FromArgb(22, 163, 74);
            btnThem.Cursor = Cursors.Hand;
            btnThem.FlatAppearance.BorderSize = 0;
            btnThem.FlatAppearance.MouseOverBackColor = Color.FromArgb(21, 128, 61);
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(20, 332);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(160, 44);
            btnThem.TabIndex = 4;
            btnThem.Text = "＋  Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            //
            // btnSua
            //
            btnSua.BackColor = Color.FromArgb(37, 99, 235);
            btnSua.Cursor = Cursors.Hand;
            btnSua.FlatAppearance.BorderSize = 0;
            btnSua.FlatAppearance.MouseOverBackColor = Color.FromArgb(29, 78, 216);
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(190, 332);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(160, 44);
            btnSua.TabIndex = 5;
            btnSua.Text = "✎  Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            //
            // btnXoa
            //
            btnXoa.BackColor = Color.FromArgb(220, 38, 38);
            btnXoa.Cursor = Cursors.Hand;
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatAppearance.MouseOverBackColor = Color.FromArgb(185, 28, 28);
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(20, 386);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(160, 44);
            btnXoa.TabIndex = 6;
            btnXoa.Text = "✕  Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            //
            // btnLamMoi
            //
            btnLamMoi.BackColor = Color.FromArgb(71, 85, 105);
            btnLamMoi.Cursor = Cursors.Hand;
            btnLamMoi.FlatAppearance.BorderSize = 0;
            btnLamMoi.FlatAppearance.MouseOverBackColor = Color.FromArgb(51, 65, 85);
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(190, 386);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(160, 44);
            btnLamMoi.TabIndex = 7;
            btnLamMoi.Text = "⟳  Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            //
            // lblGhiChu
            //
            lblGhiChu.Font = new Font("Segoe UI", 9F);
            lblGhiChu.ForeColor = Color.FromArgb(100, 116, 139);
            lblGhiChu.Location = new Point(18, 446);
            lblGhiChu.Name = "lblGhiChu";
            lblGhiChu.Size = new Size(334, 92);
            lblGhiChu.Text = "Hướng dẫn:\r\n• Chọn một dòng trên danh sách để sửa hoặc xóa.\r\n" +
                             "• Mã môn học là khóa chính nên bị khóa khi sửa.\r\n" +
                             "• Bấm \"Làm mới\" để quay lại chế độ thêm mới.\r\n" +
                             "• (*) là thông tin bắt buộc.";
            //
            // pnlDanhSach
            //
            pnlDanhSach.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlDanhSach.BackColor = Color.White;
            pnlDanhSach.Controls.Add(dgvMonHoc);
            pnlDanhSach.Controls.Add(btnTimKiem);
            pnlDanhSach.Controls.Add(pnlTimKiem);
            pnlDanhSach.Controls.Add(lblHeaderDanhSach);
            pnlDanhSach.Location = new Point(408, 94);
            pnlDanhSach.Name = "pnlDanhSach";
            pnlDanhSach.Size = new Size(672, 544);
            pnlDanhSach.TabIndex = 2;
            pnlDanhSach.Paint += The_Paint;
            pnlDanhSach.Resize += VeLai_Resize;
            //
            // lblHeaderDanhSach
            //
            lblHeaderDanhSach.AutoSize = true;
            lblHeaderDanhSach.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblHeaderDanhSach.ForeColor = Color.FromArgb(30, 64, 175);
            lblHeaderDanhSach.Location = new Point(18, 16);
            lblHeaderDanhSach.Name = "lblHeaderDanhSach";
            lblHeaderDanhSach.Text = "DANH SÁCH MÔN HỌC";
            //
            // pnlTimKiem
            //
            pnlTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlTimKiem.BackColor = Color.White;
            pnlTimKiem.Controls.Add(txtTimKiem);
            pnlTimKiem.Location = new Point(20, 50);
            pnlTimKiem.Name = "pnlTimKiem";
            pnlTimKiem.Padding = new Padding(12, 9, 12, 6);
            pnlTimKiem.Size = new Size(472, 42);
            pnlTimKiem.Paint += KhungNhap_Paint;
            pnlTimKiem.Click += KhungNhap_Click;
            pnlTimKiem.Resize += VeLai_Resize;
            //
            // txtTimKiem
            //
            txtTimKiem.BackColor = Color.White;
            txtTimKiem.BorderStyle = BorderStyle.None;
            txtTimKiem.Dock = DockStyle.Fill;
            txtTimKiem.Font = new Font("Segoe UI", 11F);
            txtTimKiem.ForeColor = Color.FromArgb(15, 23, 42);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Nhập mã hoặc tên môn học cần tìm...";
            txtTimKiem.TabIndex = 8;
            txtTimKiem.KeyDown += txtTimKiem_KeyDown;
            txtTimKiem.Enter += O_DoiFocus;
            txtTimKiem.Leave += O_DoiFocus;
            //
            // btnTimKiem
            //
            btnTimKiem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnTimKiem.BackColor = Color.FromArgb(79, 70, 229);
            btnTimKiem.Cursor = Cursors.Hand;
            btnTimKiem.FlatAppearance.BorderSize = 0;
            btnTimKiem.FlatAppearance.MouseOverBackColor = Color.FromArgb(67, 56, 202);
            btnTimKiem.FlatStyle = FlatStyle.Flat;
            btnTimKiem.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnTimKiem.ForeColor = Color.White;
            btnTimKiem.Location = new Point(502, 50);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(150, 42);
            btnTimKiem.TabIndex = 9;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = false;
            btnTimKiem.Click += btnTimKiem_Click;
            //
            // dgvMonHoc
            //
            dgvMonHoc.AllowUserToAddRows = false;
            dgvMonHoc.AllowUserToDeleteRows = false;
            dgvMonHoc.AllowUserToResizeRows = false;
            styleAlt.BackColor = Color.FromArgb(248, 250, 252);
            dgvMonHoc.AlternatingRowsDefaultCellStyle = styleAlt;
            dgvMonHoc.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMonHoc.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMonHoc.BackgroundColor = Color.White;
            dgvMonHoc.BorderStyle = BorderStyle.None;
            dgvMonHoc.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvMonHoc.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            styleHeader.Alignment = DataGridViewContentAlignment.MiddleLeft;
            styleHeader.BackColor = Color.FromArgb(239, 246, 255);
            styleHeader.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            styleHeader.ForeColor = Color.FromArgb(30, 64, 175);
            styleHeader.Padding = new Padding(8, 0, 0, 0);
            styleHeader.SelectionBackColor = Color.FromArgb(239, 246, 255);
            styleHeader.SelectionForeColor = Color.FromArgb(30, 64, 175);
            styleHeader.WrapMode = DataGridViewTriState.False;
            dgvMonHoc.ColumnHeadersDefaultCellStyle = styleHeader;
            dgvMonHoc.ColumnHeadersHeight = 44;
            dgvMonHoc.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvMonHoc.Columns.AddRange(new DataGridViewColumn[] { colMaMonHoc, colTenMonHoc, colSoTinChi, colTrangThai });
            styleCell.BackColor = Color.White;
            styleCell.Font = new Font("Segoe UI", 10F);
            styleCell.ForeColor = Color.FromArgb(30, 41, 59);
            styleCell.Padding = new Padding(8, 0, 0, 0);
            styleCell.SelectionBackColor = Color.FromArgb(219, 234, 254);
            styleCell.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dgvMonHoc.DefaultCellStyle = styleCell;
            dgvMonHoc.EnableHeadersVisualStyles = false;
            dgvMonHoc.GridColor = Color.FromArgb(226, 232, 240);
            dgvMonHoc.Location = new Point(20, 108);
            dgvMonHoc.MultiSelect = false;
            dgvMonHoc.Name = "dgvMonHoc";
            dgvMonHoc.ReadOnly = true;
            dgvMonHoc.RowHeadersVisible = false;
            dgvMonHoc.RowTemplate.Height = 38;
            dgvMonHoc.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMonHoc.Size = new Size(632, 418);
            dgvMonHoc.TabIndex = 10;
            dgvMonHoc.CellClick += dgvMonHoc_CellClick;
            dgvMonHoc.SelectionChanged += dgvMonHoc_SelectionChanged;
            //
            // colMaMonHoc
            //
            colMaMonHoc.DataPropertyName = "MaMonHoc";
            colMaMonHoc.FillWeight = 22F;
            colMaMonHoc.HeaderText = "Mã môn học";
            colMaMonHoc.Name = "colMaMonHoc";
            colMaMonHoc.ReadOnly = true;
            //
            // colTenMonHoc
            //
            colTenMonHoc.DataPropertyName = "TenMonHoc";
            colTenMonHoc.FillWeight = 46F;
            colTenMonHoc.HeaderText = "Tên môn học";
            colTenMonHoc.Name = "colTenMonHoc";
            colTenMonHoc.ReadOnly = true;
            //
            // colSoTinChi
            //
            colSoTinChi.DataPropertyName = "SoTinChi";
            styleCenter.Alignment = DataGridViewContentAlignment.MiddleCenter;
            styleCenter.Padding = new Padding(0);
            colSoTinChi.DefaultCellStyle = styleCenter;
            colSoTinChi.FillWeight = 14F;
            colSoTinChi.HeaderText = "Số tín chỉ";
            colSoTinChi.Name = "colSoTinChi";
            colSoTinChi.ReadOnly = true;
            //
            // colTrangThai
            //
            colTrangThai.DataPropertyName = "TrangThai";
            colTrangThai.FillWeight = 18F;
            colTrangThai.HeaderText = "Còn sử dụng";
            colTrangThai.Name = "colTrangThai";
            colTrangThai.ReadOnly = true;
            //
            // ssTrangThai
            //
            ssTrangThai.BackColor = Color.White;
            ssTrangThai.Items.AddRange(new ToolStripItem[] { lblTrangThai, lblTongSo });
            ssTrangThai.Location = new Point(0, 654);
            ssTrangThai.Name = "ssTrangThai";
            ssTrangThai.Padding = new Padding(12, 2, 12, 2);
            ssTrangThai.Size = new Size(1100, 26);
            ssTrangThai.SizingGrip = false;
            ssTrangThai.TabIndex = 3;
            //
            // lblTrangThai
            //
            lblTrangThai.ForeColor = Color.FromArgb(71, 85, 105);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Spring = true;
            lblTrangThai.Text = "Sẵn sàng.";
            lblTrangThai.TextAlign = ContentAlignment.MiddleLeft;
            //
            // lblTongSo
            //
            lblTongSo.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTongSo.ForeColor = Color.FromArgb(30, 64, 175);
            lblTongSo.Name = "lblTongSo";
            lblTongSo.Text = "Tổng: 0 môn học";
            //
            // FrmMonHoc
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(241, 245, 249);
            ClientSize = new Size(1100, 680);
            Controls.Add(pnlDanhSach);
            Controls.Add(pnlThongTin);
            Controls.Add(ssTrangThai);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI", 10F);
            MinimumSize = new Size(1000, 640);
            Name = "FrmMonHoc";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EduManager - Quản lý môn học";
            Load += FrmMonHoc_Load;
            Shown += FrmMonHoc_Shown;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlThongTin.ResumeLayout(false);
            pnlThongTin.PerformLayout();
            pnlSoTinChi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)nudSoTinChi).EndInit();
            pnlTenMonHoc.ResumeLayout(false);
            pnlTenMonHoc.PerformLayout();
            pnlMaMonHoc.ResumeLayout(false);
            pnlMaMonHoc.PerformLayout();
            pnlDanhSach.ResumeLayout(false);
            pnlDanhSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMonHoc).EndInit();
            pnlTimKiem.ResumeLayout(false);
            pnlTimKiem.PerformLayout();
            ssTrangThai.ResumeLayout(false);
            ssTrangThai.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblSubTitle;
        private Panel pnlThongTin;
        private Label lblHeaderThongTin;
        private Label lblCheDo;
        private Label lblMaMonHoc;
        private Panel pnlMaMonHoc;
        private TextBox txtMaMonHoc;
        private Label lblTenMonHoc;
        private Panel pnlTenMonHoc;
        private TextBox txtTenMonHoc;
        private Label lblSoTinChi;
        private Panel pnlSoTinChi;
        private NumericUpDown nudSoTinChi;
        private CheckBox chkTrangThai;
        private Panel pnlLine;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Label lblGhiChu;
        private Panel pnlDanhSach;
        private Label lblHeaderDanhSach;
        private Panel pnlTimKiem;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private DataGridView dgvMonHoc;
        private DataGridViewTextBoxColumn colMaMonHoc;
        private DataGridViewTextBoxColumn colTenMonHoc;
        private DataGridViewTextBoxColumn colSoTinChi;
        private DataGridViewCheckBoxColumn colTrangThai;
        private StatusStrip ssTrangThai;
        private ToolStripStatusLabel lblTrangThai;
        private ToolStripStatusLabel lblTongSo;
    }
}

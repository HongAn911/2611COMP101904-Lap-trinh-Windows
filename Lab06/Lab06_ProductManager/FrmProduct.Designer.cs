namespace ProductManager;

partial class FrmProduct
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

        menuStrip1 = new MenuStrip();
        mnuFile = new ToolStripMenuItem();
        mnuFileLamMoi = new ToolStripMenuItem();
        mnuFileSep = new ToolStripSeparator();
        mnuFileExit = new ToolStripMenuItem();
        mnuQuanLy = new ToolStripMenuItem();
        mnuQuanLyThem = new ToolStripMenuItem();
        mnuQuanLySua = new ToolStripMenuItem();
        mnuQuanLyXoa = new ToolStripMenuItem();
        mnuQuanLyTimKiem = new ToolStripMenuItem();
        mnuTroGiup = new ToolStripMenuItem();
        mnuTroGiupGioiThieu = new ToolStripMenuItem();

        toolStrip1 = new ToolStrip();
        tsbThem = new ToolStripButton();
        tsbSua = new ToolStripButton();
        tsbXoa = new ToolStripButton();
        tsbLamMoi = new ToolStripButton();
        tsbSep = new ToolStripSeparator();
        tsbTimKiem = new ToolStripButton();

        statusStrip1 = new StatusStrip();
        lblStatus = new ToolStripStatusLabel();

        grpThongTin = new GroupBox();
        lblMaSP = new Label();
        txtMaSP = new TextBox();
        lblTenSP = new Label();
        txtTenSP = new TextBox();
        lblLoaiSP = new Label();
        cboLoaiSP = new ComboBox();
        lblDonGia = new Label();
        numDonGia = new NumericUpDown();
        lblSoLuong = new Label();
        numSoLuong = new NumericUpDown();
        lblNgayNhap = new Label();
        dtpNgayNhap = new DateTimePicker();
        chkConKinhDoanh = new CheckBox();
        picSanPham = new PictureBox();
        btnChonAnh = new Button();
        btnThem = new Button();
        btnSua = new Button();
        btnXoa = new Button();
        btnLamMoi = new Button();

        pnlTimKiem = new Panel();
        lblTimKiem = new Label();
        txtTimKiem = new TextBox();
        btnTimKiem = new Button();

        dgvProducts = new DataGridView();
        cmsProducts = new ContextMenuStrip(components);
        cmsSua = new ToolStripMenuItem();
        cmsXoa = new ToolStripMenuItem();
        cmsChiTiet = new ToolStripMenuItem();
        errorProvider1 = new ErrorProvider(components);

        menuStrip1.SuspendLayout();
        toolStrip1.SuspendLayout();
        statusStrip1.SuspendLayout();
        grpThongTin.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)numDonGia).BeginInit();
        ((System.ComponentModel.ISupportInitialize)numSoLuong).BeginInit();
        ((System.ComponentModel.ISupportInitialize)picSanPham).BeginInit();
        pnlTimKiem.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvProducts).BeginInit();
        cmsProducts.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
        SuspendLayout();

        // menuStrip1
        menuStrip1.Items.AddRange(new ToolStripItem[] { mnuFile, mnuQuanLy, mnuTroGiup });
        menuStrip1.Name = "menuStrip1";
        menuStrip1.TabIndex = 0;

        mnuFile.DropDownItems.AddRange(new ToolStripItem[] { mnuFileLamMoi, mnuFileSep, mnuFileExit });
        mnuFile.Name = "mnuFile";
        mnuFile.Text = "File";

        mnuFileLamMoi.Name = "mnuFileLamMoi";
        mnuFileLamMoi.ShortcutKeys = Keys.F5;
        mnuFileLamMoi.Text = "Làm mới";
        mnuFileLamMoi.Click += btnLamMoi_Click;

        mnuFileSep.Name = "mnuFileSep";

        mnuFileExit.Name = "mnuFileExit";
        mnuFileExit.ShortcutKeys = Keys.Alt | Keys.F4;
        mnuFileExit.Text = "Thoát";
        mnuFileExit.Click += mnuFileExit_Click;

        mnuQuanLy.DropDownItems.AddRange(new ToolStripItem[] { mnuQuanLyThem, mnuQuanLySua, mnuQuanLyXoa, mnuQuanLyTimKiem });
        mnuQuanLy.Name = "mnuQuanLy";
        mnuQuanLy.Text = "Quản lý";

        mnuQuanLyThem.Name = "mnuQuanLyThem";
        mnuQuanLyThem.ShortcutKeys = Keys.Control | Keys.N;
        mnuQuanLyThem.Text = "Thêm sản phẩm";
        mnuQuanLyThem.Click += btnThem_Click;

        mnuQuanLySua.Name = "mnuQuanLySua";
        mnuQuanLySua.ShortcutKeys = Keys.Control | Keys.E;
        mnuQuanLySua.Text = "Sửa sản phẩm";
        mnuQuanLySua.Click += btnSua_Click;

        mnuQuanLyXoa.Name = "mnuQuanLyXoa";
        mnuQuanLyXoa.ShortcutKeys = Keys.Control | Keys.D;
        mnuQuanLyXoa.Text = "Xóa sản phẩm";
        mnuQuanLyXoa.Click += btnXoa_Click;

        mnuQuanLyTimKiem.Name = "mnuQuanLyTimKiem";
        mnuQuanLyTimKiem.ShortcutKeys = Keys.Control | Keys.F;
        mnuQuanLyTimKiem.Text = "Tìm kiếm";
        mnuQuanLyTimKiem.Click += tsbTimKiem_Click;

        mnuTroGiup.DropDownItems.AddRange(new ToolStripItem[] { mnuTroGiupGioiThieu });
        mnuTroGiup.Name = "mnuTroGiup";
        mnuTroGiup.Text = "Trợ giúp";

        mnuTroGiupGioiThieu.Name = "mnuTroGiupGioiThieu";
        mnuTroGiupGioiThieu.Text = "Giới thiệu";
        mnuTroGiupGioiThieu.Click += mnuTroGiupGioiThieu_Click;

        // toolStrip1
        toolStrip1.Items.AddRange(new ToolStripItem[] { tsbThem, tsbSua, tsbXoa, tsbLamMoi, tsbSep, tsbTimKiem });
        toolStrip1.Name = "toolStrip1";
        toolStrip1.TabIndex = 1;

        tsbThem.DisplayStyle = ToolStripItemDisplayStyle.Text;
        tsbThem.Name = "tsbThem";
        tsbThem.Text = "Thêm";
        tsbThem.ToolTipText = "Thêm sản phẩm (Ctrl+N)";
        tsbThem.Click += btnThem_Click;

        tsbSua.DisplayStyle = ToolStripItemDisplayStyle.Text;
        tsbSua.Name = "tsbSua";
        tsbSua.Text = "Sửa";
        tsbSua.ToolTipText = "Sửa sản phẩm (Ctrl+E)";
        tsbSua.Click += btnSua_Click;

        tsbXoa.DisplayStyle = ToolStripItemDisplayStyle.Text;
        tsbXoa.Name = "tsbXoa";
        tsbXoa.Text = "Xóa";
        tsbXoa.ToolTipText = "Xóa sản phẩm (Ctrl+D hoặc phím Delete trên lưới)";
        tsbXoa.Click += btnXoa_Click;

        tsbLamMoi.DisplayStyle = ToolStripItemDisplayStyle.Text;
        tsbLamMoi.Name = "tsbLamMoi";
        tsbLamMoi.Text = "Làm mới";
        tsbLamMoi.ToolTipText = "Làm mới (F5)";
        tsbLamMoi.Click += btnLamMoi_Click;

        tsbSep.Name = "tsbSep";

        tsbTimKiem.DisplayStyle = ToolStripItemDisplayStyle.Text;
        tsbTimKiem.Name = "tsbTimKiem";
        tsbTimKiem.Text = "Tìm kiếm";
        tsbTimKiem.ToolTipText = "Tìm kiếm (Ctrl+F)";
        tsbTimKiem.Click += tsbTimKiem_Click;

        // statusStrip1
        statusStrip1.Items.AddRange(new ToolStripItem[] { lblStatus });
        statusStrip1.Name = "statusStrip1";
        statusStrip1.TabIndex = 2;

        lblStatus.Name = "lblStatus";
        lblStatus.Text = "Sẵn sàng";

        // grpThongTin
        grpThongTin.Controls.Add(lblMaSP);
        grpThongTin.Controls.Add(txtMaSP);
        grpThongTin.Controls.Add(lblTenSP);
        grpThongTin.Controls.Add(txtTenSP);
        grpThongTin.Controls.Add(lblLoaiSP);
        grpThongTin.Controls.Add(cboLoaiSP);
        grpThongTin.Controls.Add(lblDonGia);
        grpThongTin.Controls.Add(numDonGia);
        grpThongTin.Controls.Add(lblSoLuong);
        grpThongTin.Controls.Add(numSoLuong);
        grpThongTin.Controls.Add(lblNgayNhap);
        grpThongTin.Controls.Add(dtpNgayNhap);
        grpThongTin.Controls.Add(chkConKinhDoanh);
        grpThongTin.Controls.Add(picSanPham);
        grpThongTin.Controls.Add(btnChonAnh);
        grpThongTin.Controls.Add(btnThem);
        grpThongTin.Controls.Add(btnSua);
        grpThongTin.Controls.Add(btnXoa);
        grpThongTin.Controls.Add(btnLamMoi);
        grpThongTin.Dock = DockStyle.Top;
        grpThongTin.Name = "grpThongTin";
        grpThongTin.Padding = new Padding(8);
        grpThongTin.Size = new Size(880, 220);
        grpThongTin.TabIndex = 0;
        grpThongTin.TabStop = false;
        grpThongTin.Text = "Thông tin sản phẩm";

        lblMaSP.AutoSize = true;
        lblMaSP.Location = new Point(15, 32);
        lblMaSP.Name = "lblMaSP";
        lblMaSP.Text = "Mã SP:";

        txtMaSP.Location = new Point(100, 29);
        txtMaSP.Name = "txtMaSP";
        txtMaSP.Size = new Size(230, 23);
        txtMaSP.TabIndex = 1;

        lblTenSP.AutoSize = true;
        lblTenSP.Location = new Point(15, 66);
        lblTenSP.Name = "lblTenSP";
        lblTenSP.Text = "Tên SP:";

        txtTenSP.Location = new Point(100, 63);
        txtTenSP.Name = "txtTenSP";
        txtTenSP.Size = new Size(230, 23);
        txtTenSP.TabIndex = 2;

        lblLoaiSP.AutoSize = true;
        lblLoaiSP.Location = new Point(15, 100);
        lblLoaiSP.Name = "lblLoaiSP";
        lblLoaiSP.Text = "Loại SP:";

        cboLoaiSP.DropDownStyle = ComboBoxStyle.DropDownList;
        cboLoaiSP.Location = new Point(100, 97);
        cboLoaiSP.Name = "cboLoaiSP";
        cboLoaiSP.Size = new Size(230, 23);
        cboLoaiSP.TabIndex = 3;

        lblDonGia.AutoSize = true;
        lblDonGia.Location = new Point(360, 32);
        lblDonGia.Name = "lblDonGia";
        lblDonGia.Text = "Đơn giá:";

        numDonGia.Location = new Point(450, 29);
        numDonGia.Maximum = 100000000000m;
        numDonGia.Minimum = 0m;
        numDonGia.Increment = 1000m;
        numDonGia.ThousandsSeparator = true;
        numDonGia.Name = "numDonGia";
        numDonGia.Size = new Size(170, 23);
        numDonGia.TabIndex = 4;

        lblSoLuong.AutoSize = true;
        lblSoLuong.Location = new Point(360, 66);
        lblSoLuong.Name = "lblSoLuong";
        lblSoLuong.Text = "Số lượng:";

        numSoLuong.Location = new Point(450, 63);
        numSoLuong.Maximum = 1000000m;
        numSoLuong.Minimum = 0m;
        numSoLuong.Name = "numSoLuong";
        numSoLuong.Size = new Size(170, 23);
        numSoLuong.TabIndex = 5;

        lblNgayNhap.AutoSize = true;
        lblNgayNhap.Location = new Point(360, 100);
        lblNgayNhap.Name = "lblNgayNhap";
        lblNgayNhap.Text = "Ngày nhập:";

        dtpNgayNhap.Format = DateTimePickerFormat.Short;
        dtpNgayNhap.Location = new Point(450, 97);
        dtpNgayNhap.Name = "dtpNgayNhap";
        dtpNgayNhap.Size = new Size(170, 23);
        dtpNgayNhap.TabIndex = 6;

        chkConKinhDoanh.AutoSize = true;
        chkConKinhDoanh.Checked = true;
        chkConKinhDoanh.CheckState = CheckState.Checked;
        chkConKinhDoanh.Location = new Point(450, 133);
        chkConKinhDoanh.Name = "chkConKinhDoanh";
        chkConKinhDoanh.TabIndex = 7;
        chkConKinhDoanh.Text = "Còn kinh doanh";

        picSanPham.BorderStyle = BorderStyle.FixedSingle;
        picSanPham.Location = new Point(660, 25);
        picSanPham.Name = "picSanPham";
        picSanPham.Size = new Size(140, 140);
        picSanPham.SizeMode = PictureBoxSizeMode.Zoom;
        picSanPham.TabStop = false;

        btnChonAnh.Location = new Point(660, 172);
        btnChonAnh.Name = "btnChonAnh";
        btnChonAnh.Size = new Size(140, 30);
        btnChonAnh.TabIndex = 8;
        btnChonAnh.Text = "Chọn ảnh...";
        btnChonAnh.UseVisualStyleBackColor = true;
        btnChonAnh.Click += btnChonAnh_Click;

        btnThem.Location = new Point(15, 172);
        btnThem.Name = "btnThem";
        btnThem.Size = new Size(100, 32);
        btnThem.TabIndex = 9;
        btnThem.Text = "Thêm";
        btnThem.UseVisualStyleBackColor = true;
        btnThem.Click += btnThem_Click;

        btnSua.Location = new Point(125, 172);
        btnSua.Name = "btnSua";
        btnSua.Size = new Size(100, 32);
        btnSua.TabIndex = 10;
        btnSua.Text = "Sửa";
        btnSua.UseVisualStyleBackColor = true;
        btnSua.Click += btnSua_Click;

        btnXoa.Location = new Point(235, 172);
        btnXoa.Name = "btnXoa";
        btnXoa.Size = new Size(100, 32);
        btnXoa.TabIndex = 11;
        btnXoa.Text = "Xóa";
        btnXoa.UseVisualStyleBackColor = true;
        btnXoa.Click += btnXoa_Click;

        btnLamMoi.Location = new Point(345, 172);
        btnLamMoi.Name = "btnLamMoi";
        btnLamMoi.Size = new Size(100, 32);
        btnLamMoi.TabIndex = 12;
        btnLamMoi.Text = "Làm mới";
        btnLamMoi.UseVisualStyleBackColor = true;
        btnLamMoi.Click += btnLamMoi_Click;

        // pnlTimKiem
        pnlTimKiem.Controls.Add(lblTimKiem);
        pnlTimKiem.Controls.Add(txtTimKiem);
        pnlTimKiem.Controls.Add(btnTimKiem);
        pnlTimKiem.Dock = DockStyle.Top;
        pnlTimKiem.Name = "pnlTimKiem";
        pnlTimKiem.Size = new Size(880, 42);
        pnlTimKiem.TabIndex = 1;

        lblTimKiem.AutoSize = true;
        lblTimKiem.Location = new Point(15, 13);
        lblTimKiem.Name = "lblTimKiem";
        lblTimKiem.Text = "Tìm kiếm:";

        txtTimKiem.Location = new Point(100, 10);
        txtTimKiem.Name = "txtTimKiem";
        txtTimKiem.PlaceholderText = "Nhập mã hoặc tên sản phẩm";
        txtTimKiem.Size = new Size(320, 23);
        txtTimKiem.TabIndex = 13;
        txtTimKiem.KeyDown += txtTimKiem_KeyDown;

        btnTimKiem.Location = new Point(430, 7);
        btnTimKiem.Name = "btnTimKiem";
        btnTimKiem.Size = new Size(100, 29);
        btnTimKiem.TabIndex = 14;
        btnTimKiem.Text = "Tìm kiếm";
        btnTimKiem.UseVisualStyleBackColor = true;
        btnTimKiem.Click += btnTimKiem_Click;

        // dgvProducts
        dgvProducts.AllowUserToAddRows = false;
        dgvProducts.AllowUserToDeleteRows = false;
        dgvProducts.AllowUserToResizeRows = false;
        dgvProducts.BackgroundColor = SystemColors.Window;
        dgvProducts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvProducts.ContextMenuStrip = cmsProducts;
        dgvProducts.Dock = DockStyle.Fill;
        dgvProducts.MultiSelect = false;
        dgvProducts.Name = "dgvProducts";
        dgvProducts.ReadOnly = true;
        dgvProducts.RowHeadersVisible = false;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.TabIndex = 15;
        dgvProducts.CellClick += dgvProducts_CellClick;
        dgvProducts.CellDoubleClick += dgvProducts_CellDoubleClick;
        dgvProducts.CellMouseDown += dgvProducts_CellMouseDown;
        dgvProducts.KeyDown += dgvProducts_KeyDown;
        dgvProducts.KeyUp += dgvProducts_KeyUp;

        // cmsProducts
        cmsProducts.Items.AddRange(new ToolStripItem[] { cmsSua, cmsXoa, cmsChiTiet });
        cmsProducts.Name = "cmsProducts";

        cmsSua.Name = "cmsSua";
        cmsSua.Text = "Sửa";
        cmsSua.Click += cmsSua_Click;

        cmsXoa.Name = "cmsXoa";
        cmsXoa.Text = "Xóa";
        cmsXoa.Click += btnXoa_Click;

        cmsChiTiet.Name = "cmsChiTiet";
        cmsChiTiet.Text = "Xem chi tiết";
        cmsChiTiet.Click += cmsChiTiet_Click;

        // errorProvider1
        errorProvider1.ContainerControl = this;

        // FrmProduct (thứ tự Add: control Fill trước, các control Top/Bottom sau)
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(880, 640);
        Controls.Add(dgvProducts);
        Controls.Add(pnlTimKiem);
        Controls.Add(grpThongTin);
        Controls.Add(statusStrip1);
        Controls.Add(toolStrip1);
        Controls.Add(menuStrip1);
        Font = new Font("Segoe UI", 9F);
        MainMenuStrip = menuStrip1;
        MinimumSize = new Size(900, 600);
        Name = "FrmProduct";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Quản lý sản phẩm";
        Load += FrmProduct_Load;

        menuStrip1.ResumeLayout(false);
        menuStrip1.PerformLayout();
        toolStrip1.ResumeLayout(false);
        toolStrip1.PerformLayout();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        grpThongTin.ResumeLayout(false);
        grpThongTin.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)numDonGia).EndInit();
        ((System.ComponentModel.ISupportInitialize)numSoLuong).EndInit();
        ((System.ComponentModel.ISupportInitialize)picSanPham).EndInit();
        pnlTimKiem.ResumeLayout(false);
        pnlTimKiem.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)dgvProducts).EndInit();
        cmsProducts.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private MenuStrip menuStrip1;
    private ToolStripMenuItem mnuFile;
    private ToolStripMenuItem mnuFileLamMoi;
    private ToolStripSeparator mnuFileSep;
    private ToolStripMenuItem mnuFileExit;
    private ToolStripMenuItem mnuQuanLy;
    private ToolStripMenuItem mnuQuanLyThem;
    private ToolStripMenuItem mnuQuanLySua;
    private ToolStripMenuItem mnuQuanLyXoa;
    private ToolStripMenuItem mnuQuanLyTimKiem;
    private ToolStripMenuItem mnuTroGiup;
    private ToolStripMenuItem mnuTroGiupGioiThieu;

    private ToolStrip toolStrip1;
    private ToolStripButton tsbThem;
    private ToolStripButton tsbSua;
    private ToolStripButton tsbXoa;
    private ToolStripButton tsbLamMoi;
    private ToolStripSeparator tsbSep;
    private ToolStripButton tsbTimKiem;

    private StatusStrip statusStrip1;
    private ToolStripStatusLabel lblStatus;

    private GroupBox grpThongTin;
    private Label lblMaSP;
    private TextBox txtMaSP;
    private Label lblTenSP;
    private TextBox txtTenSP;
    private Label lblLoaiSP;
    private ComboBox cboLoaiSP;
    private Label lblDonGia;
    private NumericUpDown numDonGia;
    private Label lblSoLuong;
    private NumericUpDown numSoLuong;
    private Label lblNgayNhap;
    private DateTimePicker dtpNgayNhap;
    private CheckBox chkConKinhDoanh;
    private PictureBox picSanPham;
    private Button btnChonAnh;
    private Button btnThem;
    private Button btnSua;
    private Button btnXoa;
    private Button btnLamMoi;

    private Panel pnlTimKiem;
    private Label lblTimKiem;
    private TextBox txtTimKiem;
    private Button btnTimKiem;

    private DataGridView dgvProducts;
    private ContextMenuStrip cmsProducts;
    private ToolStripMenuItem cmsSua;
    private ToolStripMenuItem cmsXoa;
    private ToolStripMenuItem cmsChiTiet;
    private ErrorProvider errorProvider1;
}

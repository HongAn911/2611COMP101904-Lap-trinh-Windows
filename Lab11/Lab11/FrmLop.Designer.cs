namespace COMP1019_Buoi11_Lab11
{
    partial class FrmLop
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
            lblMaLop = new Label();
            txtMaLop = new TextBox();
            lblMaKhoa = new Label();
            cboMaKhoa = new ComboBox();
            lblTenLop = new Label();
            txtTenLop = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            txtTimKiem = new TextBox();
            btnTimKiem = new Button();
            dgvLop = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvLop).BeginInit();
            SuspendLayout();
            // 
            // lblMaLop
            // 
            lblMaLop.AutoSize = true;
            lblMaLop.Location = new Point(20, 23);
            lblMaLop.Name = "lblMaLop";
            lblMaLop.Text = "Mã lớp:";
            // 
            // txtMaLop
            // 
            txtMaLop.Location = new Point(100, 20);
            txtMaLop.Name = "txtMaLop";
            txtMaLop.Size = new Size(200, 27);
            txtMaLop.TabIndex = 0;
            // 
            // lblMaKhoa
            // 
            lblMaKhoa.AutoSize = true;
            lblMaKhoa.Location = new Point(330, 23);
            lblMaKhoa.Name = "lblMaKhoa";
            lblMaKhoa.Text = "Mã khoa:";
            // 
            // cboMaKhoa
            // 
            cboMaKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboMaKhoa.Location = new Point(400, 20);
            cboMaKhoa.Name = "cboMaKhoa";
            cboMaKhoa.Size = new Size(180, 28);
            cboMaKhoa.TabIndex = 9;
            // 
            // lblTenLop
            // 
            lblTenLop.AutoSize = true;
            lblTenLop.Location = new Point(20, 63);
            lblTenLop.Name = "lblTenLop";
            lblTenLop.Text = "Tên lớp:";
            // 
            // txtTenLop
            // 
            txtTenLop.Location = new Point(100, 60);
            txtTenLop.Name = "txtTenLop";
            txtTenLop.Size = new Size(380, 27);
            txtTenLop.TabIndex = 1;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(20, 105);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 34);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.Location = new Point(130, 105);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(100, 34);
            btnSua.TabIndex = 3;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = true;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.Location = new Point(240, 105);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(100, 34);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = true;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(350, 105);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(100, 34);
            btnLamMoi.TabIndex = 5;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(20, 160);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.PlaceholderText = "Tìm theo mã hoặc tên lớp...";
            txtTimKiem.Size = new Size(330, 27);
            txtTimKiem.TabIndex = 6;
            // 
            // btnTimKiem
            // 
            btnTimKiem.Location = new Point(360, 157);
            btnTimKiem.Name = "btnTimKiem";
            btnTimKiem.Size = new Size(100, 34);
            btnTimKiem.TabIndex = 7;
            btnTimKiem.Text = "Tìm kiếm";
            btnTimKiem.UseVisualStyleBackColor = true;
            btnTimKiem.Click += btnTimKiem_Click;
            // 
            // dgvLop
            // 
            dgvLop.AllowUserToAddRows = false;
            dgvLop.AllowUserToDeleteRows = false;
            dgvLop.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLop.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLop.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLop.Location = new Point(20, 205);
            dgvLop.MultiSelect = false;
            dgvLop.Name = "dgvLop";
            dgvLop.ReadOnly = true;
            dgvLop.RowHeadersWidth = 51;
            dgvLop.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvLop.Size = new Size(560, 235);
            dgvLop.TabIndex = 8;
            dgvLop.CellClick += dgvLop_CellClick;
            // 
            // FrmLop
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 460);
            Controls.Add(dgvLop);
            Controls.Add(btnTimKiem);
            Controls.Add(txtTimKiem);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXoa);
            Controls.Add(btnSua);
            Controls.Add(btnThem);
            Controls.Add(txtTenLop);
            Controls.Add(lblTenLop);
            Controls.Add(cboMaKhoa);
            Controls.Add(lblMaKhoa);
            Controls.Add(txtMaLop);
            Controls.Add(lblMaLop);
            Name = "FrmLop";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý lớp học - EduManagerDB";
            Load += FrmLop_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLop).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMaLop;
        private TextBox txtMaLop;
        private Label lblTenLop;
        private Label lblMaKhoa;
        private ComboBox cboMaKhoa;
        private TextBox txtTenLop;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private TextBox txtTimKiem;
        private Button btnTimKiem;
        private DataGridView dgvLop;
    }
}

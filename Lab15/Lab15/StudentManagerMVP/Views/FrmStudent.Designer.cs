namespace StudentManagerMVP.Views
{
    partial class FrmStudent
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle headerStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle rowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle altRowStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle scoreStyle = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle rankStyle = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grpActions = new System.Windows.Forms.GroupBox();
            this.lblActionHint = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlLeftSpacer = new System.Windows.Forms.Panel();
            this.grpInput = new System.Windows.Forms.GroupBox();
            this.lblScoreHint = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.lblClassName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.lblStudentId = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.grpList = new System.Windows.Forms.GroupBox();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.colStudentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlMainSpacer = new System.Windows.Forms.Panel();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.pnlHeader.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.grpActions.SuspendLayout();
            this.grpInput.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.grpList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            this.grpSearch.SuspendLayout();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            //
            // pnlHeader
            //
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1084, 78);
            this.pnlHeader.TabIndex = 0;
            //
            // lblTitle
            //
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(18, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(330, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUẢN LÝ SINH VIÊN";
            //
            // lblSubtitle
            //
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(191, 219, 254);
            this.lblSubtitle.Location = new System.Drawing.Point(22, 50);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(460, 21);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "COMP1019 - Lab 15: Mô hình MVP (Model - View - Presenter)";
            //
            // pnlLeft
            //
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlLeft.Controls.Add(this.grpActions);
            this.pnlLeft.Controls.Add(this.pnlLeftSpacer);
            this.pnlLeft.Controls.Add(this.grpInput);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 78);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(12);
            this.pnlLeft.Size = new System.Drawing.Size(380, 557);
            this.pnlLeft.TabIndex = 1;
            //
            // grpInput
            //
            this.grpInput.BackColor = System.Drawing.Color.FromArgb(224, 242, 254);
            this.grpInput.Controls.Add(this.lblScoreHint);
            this.grpInput.Controls.Add(this.txtScore);
            this.grpInput.Controls.Add(this.lblScore);
            this.grpInput.Controls.Add(this.txtClassName);
            this.grpInput.Controls.Add(this.lblClassName);
            this.grpInput.Controls.Add(this.txtFullName);
            this.grpInput.Controls.Add(this.lblFullName);
            this.grpInput.Controls.Add(this.txtStudentId);
            this.grpInput.Controls.Add(this.lblStudentId);
            this.grpInput.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpInput.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.grpInput.ForeColor = System.Drawing.Color.FromArgb(3, 105, 161);
            this.grpInput.Location = new System.Drawing.Point(12, 12);
            this.grpInput.Name = "grpInput";
            this.grpInput.Size = new System.Drawing.Size(356, 250);
            this.grpInput.TabIndex = 0;
            this.grpInput.TabStop = false;
            this.grpInput.Text = "Thông tin sinh viên";
            //
            // lblStudentId
            //
            this.lblStudentId.AutoSize = true;
            this.lblStudentId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStudentId.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblStudentId.Location = new System.Drawing.Point(16, 40);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Size = new System.Drawing.Size(64, 23);
            this.lblStudentId.TabIndex = 0;
            this.lblStudentId.Text = "Mã SV:";
            //
            // txtStudentId
            //
            this.txtStudentId.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStudentId.Location = new System.Drawing.Point(110, 37);
            this.txtStudentId.MaxLength = 10;
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.PlaceholderText = "VD: SV009";
            this.txtStudentId.Size = new System.Drawing.Size(210, 30);
            this.txtStudentId.TabIndex = 1;
            //
            // lblFullName
            //
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblFullName.Location = new System.Drawing.Point(16, 85);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(69, 23);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "Họ tên:";
            //
            // txtFullName
            //
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFullName.Location = new System.Drawing.Point(110, 82);
            this.txtFullName.MaxLength = 50;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.PlaceholderText = "VD: Nguyễn Văn A";
            this.txtFullName.Size = new System.Drawing.Size(210, 30);
            this.txtFullName.TabIndex = 3;
            //
            // lblClassName
            //
            this.lblClassName.AutoSize = true;
            this.lblClassName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblClassName.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblClassName.Location = new System.Drawing.Point(16, 130);
            this.lblClassName.Name = "lblClassName";
            this.lblClassName.Size = new System.Drawing.Size(42, 23);
            this.lblClassName.TabIndex = 4;
            this.lblClassName.Text = "Lớp:";
            //
            // txtClassName
            //
            this.txtClassName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtClassName.Location = new System.Drawing.Point(110, 127);
            this.txtClassName.MaxLength = 20;
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.PlaceholderText = "VD: 49.01.SPTIN.A";
            this.txtClassName.Size = new System.Drawing.Size(210, 30);
            this.txtClassName.TabIndex = 5;
            //
            // lblScore
            //
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblScore.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblScore.Location = new System.Drawing.Point(16, 175);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(81, 23);
            this.lblScore.TabIndex = 6;
            this.lblScore.Text = "Điểm TB:";
            //
            // txtScore
            //
            this.txtScore.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtScore.Location = new System.Drawing.Point(110, 172);
            this.txtScore.MaxLength = 5;
            this.txtScore.Name = "txtScore";
            this.txtScore.PlaceholderText = "0 - 10";
            this.txtScore.Size = new System.Drawing.Size(210, 30);
            this.txtScore.TabIndex = 7;
            //
            // lblScoreHint
            //
            this.lblScoreHint.AutoSize = true;
            this.lblScoreHint.Font = new System.Drawing.Font("Segoe UI", 8.5F, System.Drawing.FontStyle.Italic);
            this.lblScoreHint.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblScoreHint.Location = new System.Drawing.Point(110, 210);
            this.lblScoreHint.Name = "lblScoreHint";
            this.lblScoreHint.Size = new System.Drawing.Size(220, 20);
            this.lblScoreHint.TabIndex = 8;
            this.lblScoreHint.Text = "Điểm từ 0 đến 10, ví dụ 8.5 hoặc 8,5";
            //
            // pnlLeftSpacer
            //
            this.pnlLeftSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeftSpacer.Location = new System.Drawing.Point(12, 262);
            this.pnlLeftSpacer.Name = "pnlLeftSpacer";
            this.pnlLeftSpacer.Size = new System.Drawing.Size(356, 12);
            this.pnlLeftSpacer.TabIndex = 1;
            //
            // grpActions
            //
            this.grpActions.BackColor = System.Drawing.Color.FromArgb(220, 252, 231);
            this.grpActions.Controls.Add(this.lblActionHint);
            this.grpActions.Controls.Add(this.btnClear);
            this.grpActions.Controls.Add(this.btnLoad);
            this.grpActions.Controls.Add(this.btnDelete);
            this.grpActions.Controls.Add(this.btnAdd);
            this.grpActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpActions.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.grpActions.ForeColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.grpActions.Location = new System.Drawing.Point(12, 274);
            this.grpActions.Name = "grpActions";
            this.grpActions.Size = new System.Drawing.Size(356, 271);
            this.grpActions.TabIndex = 2;
            this.grpActions.TabStop = false;
            this.grpActions.Text = "Chức năng";
            //
            // btnAdd
            //
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(22, 163, 74);
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(21, 128, 61);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(16, 38);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(155, 48);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm";
            this.toolTip.SetToolTip(this.btnAdd, "Thêm sinh viên mới từ các ô nhập");
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            //
            // btnDelete
            //
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(185, 28, 28);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(184, 38);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(155, 48);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Xóa theo mã";
            this.toolTip.SetToolTip(this.btnDelete, "Xóa sinh viên theo Mã SV đang nhập (hoặc dòng đang chọn)");
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            //
            // btnLoad
            //
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(29, 78, 216);
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnLoad.ForeColor = System.Drawing.Color.White;
            this.btnLoad.Location = new System.Drawing.Point(16, 100);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(155, 48);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load danh sách";
            this.toolTip.SetToolTip(this.btnLoad, "Tải lại toàn bộ danh sách sinh viên");
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            //
            // btnClear
            //
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(71, 85, 105);
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(184, 100);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(155, 48);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Làm mới";
            this.toolTip.SetToolTip(this.btnClear, "Xóa trắng ô nhập và tải lại danh sách");
            this.btnClear.UseVisualStyleBackColor = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            //
            // lblActionHint
            //
            this.lblActionHint.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblActionHint.ForeColor = System.Drawing.Color.FromArgb(22, 101, 52);
            this.lblActionHint.Location = new System.Drawing.Point(16, 162);
            this.lblActionHint.Name = "lblActionHint";
            this.lblActionHint.Size = new System.Drawing.Size(323, 90);
            this.lblActionHint.TabIndex = 4;
            this.lblActionHint.Text = "• Bấm vào một dòng để đưa dữ liệu lên ô nhập.\r\n• Xóa: nhập Mã SV hoặc chọn dòng rồi bấm Xóa.\r\n• Tìm kiếm: nhập mã hoặc một phần tên, nhấn Enter.";
            //
            // pnlMain
            //
            this.pnlMain.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.pnlMain.Controls.Add(this.grpList);
            this.pnlMain.Controls.Add(this.pnlMainSpacer);
            this.pnlMain.Controls.Add(this.grpSearch);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(380, 78);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(0, 12, 12, 12);
            this.pnlMain.Size = new System.Drawing.Size(704, 557);
            this.pnlMain.TabIndex = 2;
            //
            // grpSearch
            //
            this.grpSearch.BackColor = System.Drawing.Color.FromArgb(254, 243, 199);
            this.grpSearch.Controls.Add(this.btnSearch);
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Controls.Add(this.lblSearch);
            this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearch.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.grpSearch.ForeColor = System.Drawing.Color.FromArgb(180, 83, 9);
            this.grpSearch.Location = new System.Drawing.Point(0, 12);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(692, 88);
            this.grpSearch.TabIndex = 0;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Tìm kiếm";
            //
            // lblSearch
            //
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSearch.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            this.lblSearch.Location = new System.Drawing.Point(16, 42);
            this.lblSearch.Name = "lblSearch";
            this.lblSearch.Size = new System.Drawing.Size(115, 23);
            this.lblSearch.TabIndex = 0;
            this.lblSearch.Text = "Mã hoặc tên:";
            //
            // txtSearch
            //
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearch.Location = new System.Drawing.Point(140, 39);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "VD: SV00 hoặc huong (không cần dấu)";
            this.txtSearch.Size = new System.Drawing.Size(360, 30);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            //
            // btnSearch
            //
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(234, 88, 12);
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(194, 65, 12);
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(515, 34);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(150, 40);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            //
            // pnlMainSpacer
            //
            this.pnlMainSpacer.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMainSpacer.Location = new System.Drawing.Point(0, 100);
            this.pnlMainSpacer.Name = "pnlMainSpacer";
            this.pnlMainSpacer.Size = new System.Drawing.Size(692, 12);
            this.pnlMainSpacer.TabIndex = 1;
            //
            // grpList
            //
            this.grpList.BackColor = System.Drawing.Color.White;
            this.grpList.Controls.Add(this.dgvStudents);
            this.grpList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpList.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.grpList.ForeColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.grpList.Location = new System.Drawing.Point(0, 112);
            this.grpList.Name = "grpList";
            this.grpList.Padding = new System.Windows.Forms.Padding(10, 8, 10, 10);
            this.grpList.Size = new System.Drawing.Size(692, 433);
            this.grpList.TabIndex = 2;
            this.grpList.TabStop = false;
            this.grpList.Text = "Danh sách sinh viên";
            //
            // dgvStudents
            //
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.AllowUserToResizeRows = false;
            altRowStyle.BackColor = System.Drawing.Color.FromArgb(239, 246, 255);
            this.dgvStudents.AlternatingRowsDefaultCellStyle = altRowStyle;
            this.dgvStudents.AutoGenerateColumns = false;
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudents.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvStudents.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvStudents.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            headerStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            headerStyle.BackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            headerStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            headerStyle.ForeColor = System.Drawing.Color.White;
            headerStyle.SelectionBackColor = System.Drawing.Color.FromArgb(30, 58, 138);
            headerStyle.SelectionForeColor = System.Drawing.Color.White;
            headerStyle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            this.dgvStudents.ColumnHeadersDefaultCellStyle = headerStyle;
            this.dgvStudents.ColumnHeadersHeight = 40;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvStudents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colStudentId,
            this.colFullName,
            this.colClassName,
            this.colScore,
            this.colRank});
            rowStyle.BackColor = System.Drawing.Color.White;
            rowStyle.Font = new System.Drawing.Font("Segoe UI", 10F);
            rowStyle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            rowStyle.Padding = new System.Windows.Forms.Padding(6, 0, 0, 0);
            rowStyle.SelectionBackColor = System.Drawing.Color.FromArgb(147, 197, 253);
            rowStyle.SelectionForeColor = System.Drawing.Color.FromArgb(15, 23, 42);
            this.dgvStudents.DefaultCellStyle = rowStyle;
            this.dgvStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudents.EnableHeadersVisualStyles = false;
            this.dgvStudents.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.dgvStudents.Location = new System.Drawing.Point(10, 31);
            this.dgvStudents.MultiSelect = false;
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.RowHeadersVisible = false;
            this.dgvStudents.RowTemplate.Height = 34;
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(672, 392);
            this.dgvStudents.TabIndex = 0;
            this.dgvStudents.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudents_CellClick);
            this.dgvStudents.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStudents_CellFormatting);
            //
            // colStudentId
            //
            this.colStudentId.DataPropertyName = "StudentId";
            this.colStudentId.FillWeight = 70F;
            this.colStudentId.HeaderText = "Mã SV";
            this.colStudentId.Name = "colStudentId";
            this.colStudentId.ReadOnly = true;
            //
            // colFullName
            //
            this.colFullName.DataPropertyName = "FullName";
            this.colFullName.FillWeight = 160F;
            this.colFullName.HeaderText = "Họ tên";
            this.colFullName.Name = "colFullName";
            this.colFullName.ReadOnly = true;
            //
            // colClassName
            //
            this.colClassName.DataPropertyName = "ClassName";
            this.colClassName.FillWeight = 110F;
            this.colClassName.HeaderText = "Lớp";
            this.colClassName.Name = "colClassName";
            this.colClassName.ReadOnly = true;
            //
            // colScore
            //
            this.colScore.DataPropertyName = "Score";
            scoreStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            scoreStyle.Format = "0.0";
            this.colScore.DefaultCellStyle = scoreStyle;
            this.colScore.FillWeight = 60F;
            this.colScore.HeaderText = "Điểm TB";
            this.colScore.Name = "colScore";
            this.colScore.ReadOnly = true;
            //
            // colRank
            //
            this.colRank.DataPropertyName = "Rank";
            rankStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            rankStyle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.colRank.DefaultCellStyle = rankStyle;
            this.colRank.FillWeight = 80F;
            this.colRank.HeaderText = "Xếp loại";
            this.colRank.Name = "colRank";
            this.colRank.ReadOnly = true;
            //
            // statusStrip
            //
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblCount});
            this.statusStrip.Location = new System.Drawing.Point(0, 635);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1084, 26);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 3;
            //
            // lblStatus
            //
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(900, 20);
            this.lblStatus.Spring = true;
            this.lblStatus.Text = "Sẵn sàng";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            //
            // lblCount
            //
            this.lblCount.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(30, 58, 138);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(130, 20);
            this.lblCount.Text = "Tổng: 0 sinh viên";
            //
            // errorProvider
            //
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            //
            // FrmStudent
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.ClientSize = new System.Drawing.Size(1084, 661);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.statusStrip);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1000, 680);
            this.Name = "FrmStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lab 15 - Quản lý sinh viên (MVP)";
            this.Load += new System.EventHandler(this.FrmStudent_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.grpActions.ResumeLayout(false);
            this.grpInput.ResumeLayout(false);
            this.grpInput.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.grpList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox grpInput;
        private System.Windows.Forms.Label lblStudentId;
        private System.Windows.Forms.TextBox txtStudentId;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblClassName;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Label lblScoreHint;
        private System.Windows.Forms.Panel pnlLeftSpacer;
        private System.Windows.Forms.GroupBox grpActions;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblActionHint;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel pnlMainSpacer;
        private System.Windows.Forms.GroupBox grpList;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStudentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRank;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblCount;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

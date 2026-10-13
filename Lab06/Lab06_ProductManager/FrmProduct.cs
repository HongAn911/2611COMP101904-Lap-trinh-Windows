using System.ComponentModel;

namespace ProductManager;

public partial class FrmProduct : Form
{
    // Danh sách gốc (toàn bộ sản phẩm) lưu trong bộ nhớ.
    private readonly BindingList<Product> products = new BindingList<Product>();
    // Nguồn dữ liệu trung gian cho DataGridView.
    private readonly BindingSource productSource = new BindingSource();
    // Đường dẫn ảnh đang chọn trên form.
    private string selectedImagePath = string.Empty;

    public FrmProduct()
    {
        InitializeComponent();
        ApplyTheme();
        // Khi form hiện ra, WinForms hay tự chọn dòng đầu tiên; bỏ chọn để "chưa chọn dòng" đúng nghĩa.
        Shown += (s, e) => dgvProducts.ClearSelection();
    }

    // ======================= LOAD FORM =======================

    private void FrmProduct_Load(object? sender, EventArgs e)
    {
        cboLoaiSP.Items.AddRange(new object[]
        {
            "Điện tử", "Văn phòng", "Gia dụng", "Thời trang"
        });
        cboLoaiSP.SelectedIndex = 0;

        LoadSampleData();

        SetupGrid();
        productSource.DataSource = products;
        dgvProducts.DataSource = productSource;
        dgvProducts.ClearSelection(); // chưa chọn dòng nào

        ClearInput();
        UpdateStatus("Sẵn sàng");
    }

    private void LoadSampleData()
    {
        products.Add(new Product
        {
            MaSP = "SP01", TenSP = "Chuột không dây", LoaiSP = "Điện tử",
            DonGia = 150000, SoLuong = 20, NgayNhap = DateTime.Today.AddDays(-30),
            ConKinhDoanh = true
        });
        products.Add(new Product
        {
            MaSP = "SP02", TenSP = "Bút bi", LoaiSP = "Văn phòng",
            DonGia = 5000, SoLuong = 100, NgayNhap = DateTime.Today.AddDays(-20),
            ConKinhDoanh = true
        });
        products.Add(new Product
        {
            MaSP = "SP03", TenSP = "Nồi cơm điện", LoaiSP = "Gia dụng",
            DonGia = 850000, SoLuong = 8, NgayNhap = DateTime.Today.AddDays(-10),
            ConKinhDoanh = true
        });
        products.Add(new Product
        {
            MaSP = "SP04", TenSP = "Áo thun nam", LoaiSP = "Thời trang",
            DonGia = 120000, SoLuong = 35, NgayNhap = DateTime.Today.AddDays(-5),
            ConKinhDoanh = false
        });
        products.Add(new Product
        {
            MaSP = "SP05", TenSP = "Bàn phím cơ", LoaiSP = "Điện tử",
            DonGia = 990000, SoLuong = 12, NgayNhap = DateTime.Today,
            ConKinhDoanh = true
        });
    }

    private void SetupGrid()
    {
        dgvProducts.AutoGenerateColumns = false;
        dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProducts.ReadOnly = true;
        dgvProducts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProducts.MultiSelect = false;
        dgvProducts.AllowUserToAddRows = false;
        dgvProducts.Columns.Clear();

        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colMaSP", HeaderText = "Mã SP",
            DataPropertyName = nameof(Product.MaSP), FillWeight = 60
        });
        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colTenSP", HeaderText = "Tên sản phẩm",
            DataPropertyName = nameof(Product.TenSP), FillWeight = 140
        });
        dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
        {
            Name = "colLoaiSP", HeaderText = "Loại",
            DataPropertyName = nameof(Product.LoaiSP), FillWeight = 80
        });

        var donGia = new DataGridViewTextBoxColumn
        {
            Name = "colDonGia", HeaderText = "Đơn giá",
            DataPropertyName = nameof(Product.DonGia), FillWeight = 80
        };
        donGia.DefaultCellStyle.Format = "N0";
        donGia.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvProducts.Columns.Add(donGia);

        var soLuong = new DataGridViewTextBoxColumn
        {
            Name = "colSoLuong", HeaderText = "Số lượng",
            DataPropertyName = nameof(Product.SoLuong), FillWeight = 55
        };
        soLuong.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvProducts.Columns.Add(soLuong);

        var ngayNhap = new DataGridViewTextBoxColumn
        {
            Name = "colNgayNhap", HeaderText = "Ngày nhập",
            DataPropertyName = nameof(Product.NgayNhap), FillWeight = 75
        };
        ngayNhap.DefaultCellStyle.Format = "dd/MM/yyyy";
        dgvProducts.Columns.Add(ngayNhap);

        dgvProducts.Columns.Add(new DataGridViewCheckBoxColumn
        {
            Name = "colConKinhDoanh", HeaderText = "Còn KD",
            DataPropertyName = nameof(Product.ConKinhDoanh), FillWeight = 50
        });

        var thanhTien = new DataGridViewTextBoxColumn
        {
            Name = "colThanhTien", HeaderText = "Thành tiền",
            DataPropertyName = nameof(Product.ThanhTien), FillWeight = 90
        };
        thanhTien.DefaultCellStyle.Format = "N0";
        thanhTien.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
        dgvProducts.Columns.Add(thanhTien);
    }

    // ======================= VALIDATE =======================

    /// <summary>
    /// Kiểm tra dữ liệu nhập. editing = sản phẩm đang sửa (null khi thêm mới)
    /// để bỏ qua chính nó khi kiểm tra trùng mã.
    /// </summary>
    private bool ValidateInput(Product? editing = null)
    {
        errorProvider1.Clear();
        bool isValid = true;
        string ma = txtMaSP.Text.Trim();

        if (string.IsNullOrWhiteSpace(ma))
        {
            errorProvider1.SetError(txtMaSP, "Mã sản phẩm không được rỗng");
            isValid = false;
        }
        else if (products.Any(p => !ReferenceEquals(p, editing)
                                   && p.MaSP.Equals(ma, StringComparison.OrdinalIgnoreCase)))
        {
            errorProvider1.SetError(txtMaSP, "Mã sản phẩm đã tồn tại");
            isValid = false;
        }

        if (string.IsNullOrWhiteSpace(txtTenSP.Text))
        {
            errorProvider1.SetError(txtTenSP, "Tên sản phẩm không được rỗng");
            isValid = false;
        }

        if (cboLoaiSP.SelectedIndex < 0)
        {
            errorProvider1.SetError(cboLoaiSP, "Vui lòng chọn loại sản phẩm");
            isValid = false;
        }

        if (numDonGia.Value <= 0)
        {
            errorProvider1.SetError(numDonGia, "Đơn giá phải lớn hơn 0");
            isValid = false;
        }

        if (numSoLuong.Value < 0)
        {
            errorProvider1.SetError(numSoLuong, "Số lượng phải lớn hơn hoặc bằng 0");
            isValid = false;
        }

        if (dtpNgayNhap.Value.Date > DateTime.Today)
        {
            errorProvider1.SetError(dtpNgayNhap, "Ngày nhập không được lớn hơn ngày hiện tại");
            isValid = false;
        }

        if (!isValid)
        {
            UpdateStatus("Dữ liệu nhập chưa hợp lệ");
            MessageBox.Show("Dữ liệu nhập chưa hợp lệ. Vui lòng xem các biểu tượng cảnh báo trên form.",
                "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        return isValid;
    }

    // ======================= HÀM PHỤ TRỢ =======================

    /// <summary>Lấy sản phẩm ở dòng đang chọn; báo lỗi nếu chưa chọn dòng nào.</summary>
    private Product? GetSelectedProduct()
    {
        if (dgvProducts.SelectedRows.Count == 0
            || dgvProducts.SelectedRows[0].DataBoundItem is not Product p)
        {
            MessageBox.Show("Vui lòng chọn một sản phẩm trong danh sách.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return null;
        }
        return p;
    }

    private void ClearInput()
    {
        txtMaSP.Clear();
        txtTenSP.Clear();
        cboLoaiSP.SelectedIndex = 0;
        numDonGia.Value = 0;
        numSoLuong.Value = 0;
        dtpNgayNhap.Value = DateTime.Today;
        chkConKinhDoanh.Checked = true;
        selectedImagePath = string.Empty;
        ShowImage(string.Empty);
        errorProvider1.Clear();
        txtMaSP.Focus();
    }

    private void LoadProductToForm(Product p)
    {
        errorProvider1.Clear();
        txtMaSP.Text = p.MaSP;
        txtTenSP.Text = p.TenSP;
        cboLoaiSP.SelectedIndex = cboLoaiSP.FindStringExact(p.LoaiSP);
        numDonGia.Value = Math.Clamp(p.DonGia, numDonGia.Minimum, numDonGia.Maximum);
        numSoLuong.Value = Math.Clamp(p.SoLuong, (int)numSoLuong.Minimum, (int)numSoLuong.Maximum);
        dtpNgayNhap.Value = p.NgayNhap < dtpNgayNhap.MinDate ? dtpNgayNhap.MinDate
                          : p.NgayNhap > dtpNgayNhap.MaxDate ? dtpNgayNhap.MaxDate
                          : p.NgayNhap;
        chkConKinhDoanh.Checked = p.ConKinhDoanh;
        selectedImagePath = p.DuongDanAnh;
        ShowImage(selectedImagePath);
    }

    private void UpdateStatus(string message)
    {
        decimal tongGiaTri = products.Sum(p => p.ThanhTien);
        lblStatus.Text = $"{message} | Số sản phẩm: {products.Count} | Tổng giá trị tồn kho: {tongGiaTri:N0}";
    }

    /// <summary>Hiển thị lại toàn bộ danh sách gốc và xóa ô tìm kiếm.</summary>
    private void ShowAllProducts()
    {
        txtTimKiem.Clear();
        productSource.DataSource = products;
        productSource.ResetBindings(false);
        dgvProducts.ClearSelection();
    }

    /// <summary>Đọc ảnh từ file mà không khóa file; trả về null nếu không đọc được.</summary>
    private static Image? LoadImageSafe(string path)
    {
        if (string.IsNullOrWhiteSpace(path) || !File.Exists(path)) return null;
        try
        {
            using var stream = new FileStream(path, FileMode.Open, FileAccess.Read);
            using var img = Image.FromStream(stream);
            return new Bitmap(img);
        }
        catch (Exception ex) when (ex is ArgumentException || ex is IOException
                                   || ex is OutOfMemoryException || ex is UnauthorizedAccessException)
        {
            return null;
        }
    }

    private void ShowImage(string path)
    {
        Image? old = picSanPham.Image;
        picSanPham.Image = LoadImageSafe(path);
        old?.Dispose();
    }

    // ======================= THÊM / SỬA / XÓA =======================

    private void btnThem_Click(object? sender, EventArgs e)
    {
        if (!ValidateInput()) return;

        var p = new Product
        {
            MaSP = txtMaSP.Text.Trim(),
            TenSP = txtTenSP.Text.Trim(),
            LoaiSP = cboLoaiSP.Text,
            DonGia = numDonGia.Value,
            SoLuong = (int)numSoLuong.Value,
            NgayNhap = dtpNgayNhap.Value.Date,
            ConKinhDoanh = chkConKinhDoanh.Checked,
            DuongDanAnh = selectedImagePath
        };

        products.Add(p);
        ShowAllProducts();
        ClearInput();
        UpdateStatus("Đã thêm sản phẩm mới");
        MessageBox.Show("Thêm sản phẩm thành công!", "Thông báo",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnSua_Click(object? sender, EventArgs e)
    {
        Product? p = GetSelectedProduct();
        if (p == null) return;
        if (!ValidateInput(editing: p)) return;

        p.MaSP = txtMaSP.Text.Trim();
        p.TenSP = txtTenSP.Text.Trim();
        p.LoaiSP = cboLoaiSP.Text;
        p.DonGia = numDonGia.Value;
        p.SoLuong = (int)numSoLuong.Value;
        p.NgayNhap = dtpNgayNhap.Value.Date;
        p.ConKinhDoanh = chkConKinhDoanh.Checked;
        p.DuongDanAnh = selectedImagePath;

        productSource.ResetBindings(false);
        UpdateStatus("Đã cập nhật sản phẩm");
        MessageBox.Show("Cập nhật sản phẩm thành công!", "Thông báo",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btnXoa_Click(object? sender, EventArgs e)
    {
        Product? p = GetSelectedProduct();
        if (p == null) return;

        DialogResult result = MessageBox.Show(
            $"Bạn có chắc muốn xóa sản phẩm \"{p.TenSP}\" (mã {p.MaSP})?",
            "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (result != DialogResult.Yes) return;

        products.Remove(p);
        ShowAllProducts();
        ClearInput();
        UpdateStatus("Đã xóa sản phẩm");
    }

    // ======================= TÌM KIẾM / LÀM MỚI =======================

    private void btnTimKiem_Click(object? sender, EventArgs e)
    {
        string keyword = txtTimKiem.Text.Trim();

        if (keyword.Length == 0)
        {
            ShowAllProducts();
            UpdateStatus("Hiển thị tất cả sản phẩm");
            return;
        }

        var result = products
            .Where(p => p.MaSP.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                     || p.TenSP.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            .ToList();

        // Hiển thị kết quả; các phần tử vẫn là chính đối tượng trong danh sách gốc
        // nên Sửa/Xóa trên kết quả tìm kiếm vẫn tác động đúng dữ liệu.
        productSource.DataSource = new BindingList<Product>(result);
        dgvProducts.ClearSelection();
        UpdateStatus($"Tìm thấy {result.Count} sản phẩm");
    }

    private void txtTimKiem_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            btnTimKiem_Click(sender, EventArgs.Empty);
        }
    }

    /// <summary>Nút Tìm kiếm trên toolbar/menu: chưa có từ khóa thì đưa con trỏ vào ô tìm kiếm.</summary>
    private void tsbTimKiem_Click(object? sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtTimKiem.Text))
        {
            txtTimKiem.Focus();
            UpdateStatus("Nhập mã hoặc tên sản phẩm rồi nhấn Enter để tìm");
        }
        else
        {
            btnTimKiem_Click(sender, e);
        }
    }

    private void btnLamMoi_Click(object? sender, EventArgs e)
    {
        ShowAllProducts();
        ClearInput();
        UpdateStatus("Đã làm mới dữ liệu");
    }

    // ======================= CHỌN ẢNH =======================

    private void btnChonAnh_Click(object? sender, EventArgs e)
    {
        using var dialog = new OpenFileDialog();
        dialog.Title = "Chọn ảnh sản phẩm";
        dialog.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp";

        if (dialog.ShowDialog() != DialogResult.OK) return;

        Image? img = LoadImageSafe(dialog.FileName);
        if (img == null)
        {
            MessageBox.Show("Không thể đọc file ảnh đã chọn.", "Lỗi",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        selectedImagePath = dialog.FileName;
        Image? old = picSanPham.Image;
        picSanPham.Image = img;
        old?.Dispose();
        UpdateStatus("Đã chọn ảnh sản phẩm");
    }

    // ======================= DATAGRIDVIEW: CHUỘT / BÀN PHÍM =======================

    private void dgvProducts_CellClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        if (dgvProducts.Rows[e.RowIndex].DataBoundItem is Product p)
        {
            LoadProductToForm(p);
            UpdateStatus($"Đang chọn sản phẩm {p.MaSP}");
        }
    }

    private void dgvProducts_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex < 0) return;
        if (dgvProducts.Rows[e.RowIndex].DataBoundItem is Product p)
        {
            LoadProductToForm(p);
            txtTenSP.Focus();
        }
    }

    /// <summary>Nhấn chuột phải trên dòng nào thì chọn dòng đó trước khi hiện menu.</summary>
    private void dgvProducts_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
    {
        if (e.Button != MouseButtons.Right || e.RowIndex < 0) return;

        dgvProducts.ClearSelection();
        dgvProducts.Rows[e.RowIndex].Selected = true;
        dgvProducts.CurrentCell = dgvProducts.Rows[e.RowIndex].Cells[0];

        if (dgvProducts.Rows[e.RowIndex].DataBoundItem is Product p)
            LoadProductToForm(p);
    }

    private void dgvProducts_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Delete)
        {
            e.Handled = true;
            btnXoa_Click(sender, EventArgs.Empty);
        }
    }

    /// <summary>Dùng phím mũi tên/Home/End để duyệt dòng thì form tự cập nhật theo.</summary>
    private void dgvProducts_KeyUp(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode is Keys.Up or Keys.Down or Keys.PageUp or Keys.PageDown
                      or Keys.Home or Keys.End)
        {
            if (dgvProducts.SelectedRows.Count > 0
                && dgvProducts.SelectedRows[0].DataBoundItem is Product p)
            {
                LoadProductToForm(p);
            }
        }
    }

    // ======================= MENU / CONTEXT MENU =======================

    private void mnuFileExit_Click(object? sender, EventArgs e)
    {
        Close();
    }

    private void mnuTroGiupGioiThieu_Click(object? sender, EventArgs e)
    {
        MessageBox.Show(
            "ProductManager - Quản lý sản phẩm\nCOMP1019 - Lập trình trên Windows\n\n" +
            "Phím tắt: Ctrl+N (Thêm), Ctrl+E (Sửa), Ctrl+D hoặc Delete (Xóa),\n" +
            "Ctrl+F (Tìm kiếm), F5 (Làm mới).",
            "Giới thiệu", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    /// <summary>Menu chuột phải "Sửa": đưa dữ liệu lên form để chỉnh, sau đó nhấn nút Sửa để lưu.</summary>
    private void cmsSua_Click(object? sender, EventArgs e)
    {
        Product? p = GetSelectedProduct();
        if (p == null) return;

        LoadProductToForm(p);
        txtTenSP.Focus();
        UpdateStatus("Chỉnh sửa thông tin rồi nhấn nút Sửa để lưu");
    }

    private void cmsChiTiet_Click(object? sender, EventArgs e)
    {
        Product? p = GetSelectedProduct();
        if (p == null) return;

        MessageBox.Show(
            $"Mã: {p.MaSP}\n" +
            $"Tên: {p.TenSP}\n" +
            $"Loại: {p.LoaiSP}\n" +
            $"Đơn giá: {p.DonGia:N0}\n" +
            $"Số lượng: {p.SoLuong}\n" +
            $"Ngày nhập: {p.NgayNhap:dd/MM/yyyy}\n" +
            $"Tình trạng: {(p.ConKinhDoanh ? "Còn kinh doanh" : "Ngừng kinh doanh")}\n" +
            $"Thành tiền: {p.ThanhTien:N0}\n" +
            $"Ảnh: {(string.IsNullOrWhiteSpace(p.DuongDanAnh) ? "(chưa có)" : p.DuongDanAnh)}",
            "Chi tiết sản phẩm", MessageBoxButtons.OK, MessageBoxIcon.Information);
        UpdateStatus($"Đã xem chi tiết sản phẩm {p.MaSP}");
    }
}

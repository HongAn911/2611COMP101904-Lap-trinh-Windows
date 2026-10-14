using System.ComponentModel;
using System.Globalization;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    /// <summary>
    /// Form con MDI quản lý sản phẩm: thêm, sửa, xóa, làm mới, tìm kiếm (dữ liệu trong bộ nhớ).
    /// </summary>
    public partial class FrmProduct : Form
    {
        private readonly BindingList<Product> _products;
        private readonly BindingSource _bindingSource = new BindingSource();
        private bool _loading; // tránh nạp lại ô nhập khi đang gán lại DataSource

        /// <summary>
        /// Danh sách sản phẩm được truyền từ FrmMain qua constructor.
        /// </summary>
        public FrmProduct(BindingList<Product> products)
        {
            InitializeComponent();
            _products = products;

            SetupGrid();

            cboCategory.Items.AddRange(new object[]
            {
                "Đồ uống", "Thực phẩm", "Gia dụng", "Văn phòng phẩm", "Khác"
            });
            cboCategory.SelectedIndex = 0;

            dgvProducts.DataSource = _bindingSource;
            ShowList(_products);
        }

        private void SetupGrid()
        {
            dgvProducts.AutoGenerateColumns = false;
            dgvProducts.Columns.Clear();

            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProductId",
                HeaderText = "Mã SP",
                DataPropertyName = "ProductId",
                FillWeight = 15
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colProductName",
                HeaderText = "Tên sản phẩm",
                DataPropertyName = "ProductName",
                FillWeight = 35
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCategory",
                HeaderText = "Loại",
                DataPropertyName = "Category",
                FillWeight = 20
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPrice",
                HeaderText = "Đơn giá",
                DataPropertyName = "Price",
                FillWeight = 17,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Format = "N0",
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });
            dgvProducts.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colQuantity",
                HeaderText = "Số lượng",
                DataPropertyName = "Quantity",
                FillWeight = 13,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });
        }

        /// <summary>
        /// Hiển thị một danh sách (toàn bộ hoặc kết quả tìm kiếm) lên DataGridView.
        /// </summary>
        private void ShowList(IList<Product> list)
        {
            _loading = true;
            _bindingSource.DataSource = list;
            dgvProducts.ClearSelection();
            _loading = false;
        }

        private void ClearInputs()
        {
            txtProductId.Clear();
            txtProductName.Clear();
            txtPrice.Clear();
            txtQuantity.Clear();
            cboCategory.SelectedIndex = 0;
            txtProductId.Focus();
        }

        /// <summary>
        /// Kiểm tra dữ liệu nhập. Trả về true nếu hợp lệ và xuất giá trị đã chuyển kiểu.
        /// </summary>
        private bool TryGetInput(out string id, out string name, out string category,
            out decimal price, out int quantity)
        {
            id = txtProductId.Text.Trim();
            name = txtProductName.Text.Trim();
            category = cboCategory.Text;
            price = 0;
            quantity = 0;

            if (id.Length == 0)
            {
                Warn("Vui lòng nhập mã sản phẩm.", txtProductId);
                return false;
            }

            if (name.Length == 0)
            {
                Warn("Vui lòng nhập tên sản phẩm.", txtProductName);
                return false;
            }

            if (string.IsNullOrWhiteSpace(category))
            {
                Warn("Vui lòng chọn loại sản phẩm.", cboCategory);
                return false;
            }

            if (!decimal.TryParse(txtPrice.Text.Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out price))
            {
                Warn("Đơn giá phải là một số hợp lệ.", txtPrice);
                return false;
            }

            if (price < 0)
            {
                Warn("Đơn giá không được âm.", txtPrice);
                return false;
            }

            if (!int.TryParse(txtQuantity.Text.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture, out quantity))
            {
                Warn("Số lượng phải là một số nguyên hợp lệ.", txtQuantity);
                return false;
            }

            if (quantity < 0)
            {
                Warn("Số lượng không được âm.", txtQuantity);
                return false;
            }

            return true;
        }

        private static void Warn(string message, Control focusControl)
        {
            MessageBox.Show(message, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focusControl.Focus();
        }

        private Product FindById(string id)
        {
            return _products.FirstOrDefault(p =>
                string.Equals(p.ProductId, id, StringComparison.OrdinalIgnoreCase));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!TryGetInput(out string id, out string name, out string category,
                    out decimal price, out int quantity))
            {
                return;
            }

            // Không cho thêm trùng mã
            if (FindById(id) != null)
            {
                Warn("Mã sản phẩm '" + id + "' đã tồn tại. Vui lòng nhập mã khác.", txtProductId);
                return;
            }

            _products.Add(new Product(id, name, category, price, quantity));
            txtSearch.Clear();
            ShowList(_products);
            ClearInputs();

            MessageBox.Show("Thêm sản phẩm thành công.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!TryGetInput(out string id, out string name, out string category,
                    out decimal price, out int quantity))
            {
                return;
            }

            Product existing = FindById(id);
            if (existing == null)
            {
                Warn("Không tìm thấy sản phẩm có mã '" + id + "' để sửa. " +
                     "Hãy chọn một dòng trong danh sách (mã sản phẩm không đổi khi sửa).", txtProductId);
                return;
            }

            existing.ProductName = name;
            existing.Category = category;
            existing.Price = price;
            existing.Quantity = quantity;

            txtSearch.Clear();
            ShowList(_products);
            ClearInputs();

            MessageBox.Show("Cập nhật sản phẩm thành công.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProducts.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần xóa trong danh sách.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Product selected = dgvProducts.SelectedRows[0].DataBoundItem as Product;
            if (selected == null)
            {
                return;
            }

            // Xác nhận trước khi xóa
            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa sản phẩm '" + selected.ProductName + "' (" + selected.ProductId + ")?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            _products.Remove(selected);
            txtSearch.Clear();
            ShowList(_products);
            ClearInputs();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            ShowList(_products);
            ClearInputs();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (keyword.Length == 0)
            {
                ShowList(_products);
                return;
            }

            // Tìm theo mã, tên hoặc loại (không phân biệt hoa thường)
            List<Product> found = _products.Where(p =>
                    p.ProductId.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    p.ProductName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    p.Category.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();

            ShowList(found);

            if (found.Count == 0)
            {
                MessageBox.Show("Không tìm thấy sản phẩm phù hợp.", "Kết quả tìm kiếm",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnSearch_Click(sender, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Chọn một dòng thì đưa dữ liệu lên các ô nhập để sửa.
        /// </summary>
        private void dgvProducts_SelectionChanged(object sender, EventArgs e)
        {
            if (_loading || dgvProducts.SelectedRows.Count == 0)
            {
                return;
            }

            if (dgvProducts.SelectedRows[0].DataBoundItem is Product p)
            {
                txtProductId.Text = p.ProductId;
                txtProductName.Text = p.ProductName;
                cboCategory.Text = p.Category;
                txtPrice.Text = p.Price.ToString("0.##", CultureInfo.CurrentCulture);
                txtQuantity.Text = p.Quantity.ToString(CultureInfo.CurrentCulture);
            }
        }
    }
}

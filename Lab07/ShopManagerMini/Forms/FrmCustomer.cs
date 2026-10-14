using System.ComponentModel;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    /// <summary>
    /// Form con MDI quản lý khách hàng: thêm, sửa, xóa, làm mới, tìm kiếm (dữ liệu trong bộ nhớ).
    /// </summary>
    public partial class FrmCustomer : Form
    {
        private readonly BindingList<Customer> _customers;
        private readonly BindingSource _bindingSource = new BindingSource();
        private bool _loading;

        /// <summary>
        /// Danh sách khách hàng được truyền từ FrmMain qua constructor.
        /// </summary>
        public FrmCustomer(BindingList<Customer> customers)
        {
            InitializeComponent();
            _customers = customers;

            SetupGrid();

            cboCustomerType.Items.AddRange(new object[] { "Thường", "Thân thiết", "VIP" });
            cboCustomerType.SelectedIndex = 0;

            dgvCustomers.DataSource = _bindingSource;
            ShowList(_customers);
        }

        private void SetupGrid()
        {
            dgvCustomers.AutoGenerateColumns = false;
            dgvCustomers.Columns.Clear();

            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCustomerId",
                HeaderText = "Mã KH",
                DataPropertyName = "CustomerId",
                FillWeight = 15
            });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFullName",
                HeaderText = "Họ tên",
                DataPropertyName = "FullName",
                FillWeight = 40
            });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPhone",
                HeaderText = "Số điện thoại",
                DataPropertyName = "Phone",
                FillWeight = 25
            });
            dgvCustomers.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colCustomerType",
                HeaderText = "Loại khách hàng",
                DataPropertyName = "CustomerType",
                FillWeight = 20
            });
        }

        private void ShowList(IList<Customer> list)
        {
            _loading = true;
            _bindingSource.DataSource = list;
            dgvCustomers.ClearSelection();
            _loading = false;
        }

        private void ClearInputs()
        {
            txtCustomerId.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            cboCustomerType.SelectedIndex = 0;
            txtCustomerId.Focus();
        }

        private bool TryGetInput(out string id, out string name, out string phone, out string type)
        {
            id = txtCustomerId.Text.Trim();
            name = txtFullName.Text.Trim();
            phone = txtPhone.Text.Trim();
            type = cboCustomerType.Text;

            if (id.Length == 0)
            {
                Warn("Vui lòng nhập mã khách hàng.", txtCustomerId);
                return false;
            }

            if (name.Length == 0)
            {
                Warn("Vui lòng nhập họ tên khách hàng.", txtFullName);
                return false;
            }

            if (phone.Length == 0)
            {
                Warn("Vui lòng nhập số điện thoại.", txtPhone);
                return false;
            }

            // Số điện thoại: chỉ gồm chữ số, dài 9-11 ký tự
            if (!phone.All(char.IsDigit) || phone.Length < 9 || phone.Length > 11)
            {
                Warn("Số điện thoại chỉ gồm chữ số và dài từ 9 đến 11 ký tự.", txtPhone);
                return false;
            }

            if (string.IsNullOrWhiteSpace(type))
            {
                Warn("Vui lòng chọn loại khách hàng.", cboCustomerType);
                return false;
            }

            return true;
        }

        private static void Warn(string message, Control focusControl)
        {
            MessageBox.Show(message, "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            focusControl.Focus();
        }

        private Customer FindById(string id)
        {
            return _customers.FirstOrDefault(c =>
                string.Equals(c.CustomerId, id, StringComparison.OrdinalIgnoreCase));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!TryGetInput(out string id, out string name, out string phone, out string type))
            {
                return;
            }

            if (FindById(id) != null)
            {
                Warn("Mã khách hàng '" + id + "' đã tồn tại. Vui lòng nhập mã khác.", txtCustomerId);
                return;
            }

            _customers.Add(new Customer(id, name, phone, type));
            txtSearch.Clear();
            ShowList(_customers);
            ClearInputs();

            MessageBox.Show("Thêm khách hàng thành công.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!TryGetInput(out string id, out string name, out string phone, out string type))
            {
                return;
            }

            Customer existing = FindById(id);
            if (existing == null)
            {
                Warn("Không tìm thấy khách hàng có mã '" + id + "' để sửa. " +
                     "Hãy chọn một dòng trong danh sách (mã khách hàng không đổi khi sửa).", txtCustomerId);
                return;
            }

            existing.FullName = name;
            existing.Phone = phone;
            existing.CustomerType = type;

            txtSearch.Clear();
            ShowList(_customers);
            ClearInputs();

            MessageBox.Show("Cập nhật khách hàng thành công.", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa trong danh sách.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Customer selected = dgvCustomers.SelectedRows[0].DataBoundItem as Customer;
            if (selected == null)
            {
                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa khách hàng '" + selected.FullName + "' (" + selected.CustomerId + ")?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes)
            {
                return;
            }

            _customers.Remove(selected);
            txtSearch.Clear();
            ShowList(_customers);
            ClearInputs();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            ShowList(_customers);
            ClearInputs();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();

            if (keyword.Length == 0)
            {
                ShowList(_customers);
                return;
            }

            List<Customer> found = _customers.Where(c =>
                    c.CustomerId.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    c.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    c.Phone.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();

            ShowList(found);

            if (found.Count == 0)
            {
                MessageBox.Show("Không tìm thấy khách hàng phù hợp.", "Kết quả tìm kiếm",
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

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (_loading || dgvCustomers.SelectedRows.Count == 0)
            {
                return;
            }

            if (dgvCustomers.SelectedRows[0].DataBoundItem is Customer c)
            {
                txtCustomerId.Text = c.CustomerId;
                txtFullName.Text = c.FullName;
                txtPhone.Text = c.Phone;
                cboCustomerType.Text = c.CustomerType;
            }
        }
    }
}

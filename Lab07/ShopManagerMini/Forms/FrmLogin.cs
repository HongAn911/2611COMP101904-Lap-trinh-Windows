using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    /// <summary>
    /// Form đăng nhập. Được mở bằng ShowDialog() và trả DialogResult.OK khi đăng nhập thành công.
    /// </summary>
    public partial class FrmLogin : Form
    {
        // Danh sách tài khoản mẫu (dữ liệu trong bộ nhớ)
        private static readonly List<User> SampleUsers = new List<User>
        {
            new User("admin", "123", "Quản trị viên", "Admin"),
            new User("user", "123", "Nhân viên bán hàng", "User")
        };

        /// <summary>
        /// Người dùng đã đăng nhập thành công. FrmMain đọc thông tin từ property này (qua Program).
        /// </summary>
        public User LoggedInUser { get; private set; }

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Kiểm tra bỏ trống
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu.", "Cảnh báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            // Kiểm tra tài khoản mẫu
            User found = SampleUsers.FirstOrDefault(u =>
                string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase) &&
                u.Password == password);

            if (found == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Đăng nhập thất bại",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();
                return;
            }

            LoggedInUser = found;
            DialogResult = DialogResult.OK; // Đóng form và trả kết quả OK cho nơi gọi ShowDialog()
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

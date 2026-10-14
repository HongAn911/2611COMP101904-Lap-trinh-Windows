using System.ComponentModel;
using ShopManagerMini.Models;

namespace ShopManagerMini.Forms
{
    /// <summary>
    /// Form chính dạng MDI Parent. Chứa MenuStrip, StatusStrip và quản lý các Form con.
    /// </summary>
    public partial class FrmMain : Form
    {
        private readonly User _user;

        // Dữ liệu dùng chung, nằm ở Form cha để không mất khi Form con bị đóng rồi mở lại
        private readonly BindingList<Product> _products = new BindingList<Product>();
        private readonly BindingList<Customer> _customers = new BindingList<Customer>();

        /// <summary>
        /// = true khi người dùng chọn Đăng xuất (Program sẽ hiển thị lại FrmLogin).
        /// </summary>
        public bool IsLoggedOut { get; private set; }

        /// <summary>
        /// Nhận thông tin người dùng từ FrmLogin thông qua constructor.
        /// </summary>
        public FrmMain(User user)
        {
            InitializeComponent();
            _user = user;

            IsMdiContainer = true; // bắt buộc theo yêu cầu đề bài

            lblUser.Text = "Người dùng: " + _user.FullName;
            lblRole.Text = "Vai trò: " + _user.Role;
            UpdateClock();

            SeedSampleData();
        }

        /// <summary>
        /// Dữ liệu mẫu để demo.
        /// </summary>
        private void SeedSampleData()
        {
            _products.Add(new Product("SP001", "Nước suối 500ml", "Đồ uống", 5000, 100));
            _products.Add(new Product("SP002", "Mì gói", "Thực phẩm", 4500, 200));
            _products.Add(new Product("SP003", "Bút bi xanh", "Văn phòng phẩm", 3000, 150));

            _customers.Add(new Customer("KH001", "Nguyễn Văn An", "0901234567", "Thường"));
            _customers.Add(new Customer("KH002", "Trần Thị Bình", "0912345678", "VIP"));
        }

        /// <summary>
        /// Mở Form con MDI. Nếu đã có Form cùng loại đang mở thì kích hoạt Form cũ, không tạo mới.
        /// </summary>
        private void OpenChild<T>(Func<T> factory) where T : Form
        {
            foreach (Form child in MdiChildren)
            {
                if (child is T)
                {
                    if (child.WindowState == FormWindowState.Minimized)
                    {
                        child.WindowState = FormWindowState.Normal;
                    }
                    child.Activate();
                    return;
                }
            }

            T form = factory();
            form.MdiParent = this;
            form.Show();
        }

        private void mnuProduct_Click(object sender, EventArgs e)
        {
            OpenChild(() => new FrmProduct(_products));
        }

        private void mnuCustomer_Click(object sender, EventArgs e)
        {
            OpenChild(() => new FrmCustomer(_customers));
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            OpenChild(() => new FrmAbout());
        }

        private void mnuLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn đăng xuất?", "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                IsLoggedOut = true;
                Close();
            }
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Close(); // việc xác nhận được xử lý trong OnFormClosing
        }

        /// <summary>
        /// Hỏi xác nhận khi thoát chương trình (menu Thoát hoặc nút X).
        /// </summary>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (!IsLoggedOut && e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Xác nhận thoát",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }

            base.OnFormClosing(e);
        }

        private void timerClock_Tick(object sender, EventArgs e)
        {
            UpdateClock();
        }

        private void UpdateClock()
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
    }
}

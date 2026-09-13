using System;
using System.Windows.Forms;
using System.Text.RegularExpressions;
namespace Lab01_Ungdungthongtincanhan
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(500, 400); // Đặt kích thước vùng làm việc của Form
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboKhoa.Items.Clear();
            cboKhoa.Items.Add("Sư phạm Tin học");
            cboKhoa.Items.Add("Công nghệ Thông tin");
            cboKhoa.Items.Add("Chính trị học");
            cboKhoa.Items.Add("Công tác xã hội");

            cboKhoa.SelectedIndex = -1; // Không chọn sẵn mục nào (bắt người dùng phải tự chọn)
        }
        // kiểm tra hợp lệ dữ liệu nhập, nếu OK thì hiển thị kết quả
        private void btnHienThi_Click(object sender, EventArgs e)
        {
            // 1. Họ tên không được để trống
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Họ tên không được để trống!", "Lỗi dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtHoTen.Focus();
                return;
            }
            // 2. Năm sinh không được để trống 
            if (string.IsNullOrWhiteSpace(txtNamSinh.Text))
            {
                MessageBox.Show("Năm sinh không được để trống!", "Lỗi dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamSinh.Focus();
                return;
            }
            // 3. Năm sinh phải là số nguyên 
            int namSinh;
            if (!int.TryParse(txtNamSinh.Text.Trim(), out namSinh))
            {
                MessageBox.Show("Năm sinh phải là số nguyên!", "Lỗi dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamSinh.Focus();
                return;
            }
            // 4. Năm sinh phải nằm trong khoảng hợp lệ 
            int namHienTai = DateTime.Now.Year;
            if (namSinh < 1900 || namSinh > namHienTai)
            {
                MessageBox.Show($"Năm sinh phải nằm trong khoảng từ 1900 đến {namHienTai}!",
                    "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamSinh.Focus();
                return;
            }
            // 5. Email không được để trống
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Email không được để trống!", "Lỗi dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            // 6. Email phải đúng định dạng (ví dụ:  vana@example.com)
            string mauEmail = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            if (!Regex.IsMatch(txtEmail.Text.Trim(), mauEmail))
            {
                MessageBox.Show("Email không đúng định dạng! (Ví dụ: ten@example.com)", "Lỗi dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }
            // 7. Phải chọn 1 trong 2 giới tính 
            if (!radNam.Checked && !radNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn giới tính!", "Lỗi dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string gioiTinh = radNam.Checked ? "Nam" : "Nữ";

            // 8. Phải chọn Khoa/Lớp trong ComboBox
            if (cboKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn khoa hoặc lớp!", "Lỗi dữ liệu",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboKhoa.Focus();
                return;
            }
            // Nếu các dữ liệu đều hợp lệ thì tính toán và hiển thị kết quả 
            int tuoi = namHienTai - namSinh;

            string ketQua =
                "Họ tên: " + txtHoTen.Text.Trim() + Environment.NewLine +
                "Tuổi: " + tuoi + Environment.NewLine +
                "Email: " + txtEmail.Text.Trim() + Environment.NewLine +
                "Giới tính: " + gioiTinh + Environment.NewLine +
                "Khoa/Lớp: " + cboKhoa.SelectedItem.ToString();

            MessageBox.Show(ketQua, "Thông tin sinh viên",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // đưa toàn bộ Form về trạng thái ban đầu (rỗng) 
        private void btnXoa_Click(object sender, EventArgs e)
        {
            txtHoTen.Clear();
            txtNamSinh.Clear();
            txtEmail.Clear();
            radNam.Checked = false;
            radNu.Checked = false;
            cboKhoa.SelectedIndex = -1;
            txtHoTen.Focus();
        }

        // hỏi xác nhận trước khi đóng chương trình
        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình không?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }
    }
}

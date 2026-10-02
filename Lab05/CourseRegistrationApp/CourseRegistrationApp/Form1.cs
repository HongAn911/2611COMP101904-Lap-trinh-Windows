namespace CourseRegistrationApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblTongTien_Click(object sender, EventArgs e)
        {

        }

        private void radOffline_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            private void Form1_Load(object sender, EventArgs e)
            {
                // Nạp danh sách khóa học vào ComboBox
                cboKhoaHoc.Items.Add("C# WinForms cơ bản");
                cboKhoaHoc.Items.Add("SQL Server cơ bản");
                cboKhoaHoc.Items.Add("Web Frontend cơ bản");
                cboKhoaHoc.Items.Add("Lập trình Python cơ bản");

                // Chọn mặc định khóa học đầu tiên
                cboKhoaHoc.SelectedIndex = 0;

                // Chọn mặc định hình thức Online
                radOnline.Checked = true;

                // Thiết lập số tháng tối thiểu là 1, tối đa là 12
                numSoThang.Minimum = 1;
                numSoThang.Maximum = 12;

                // Gọi hàm tính tiền để tự động hiển thị số tiền tương ứng khóa đầu tiên
                TinhTien();

                // === THÊM 2 DÒNG NÀY VÀO CUỐI HÀM ĐỂ KẾT NỐI SỰ KIỆN ===
                cboKhoaHoc.SelectedIndexChanged += cboKhoaHoc_SelectedIndexChanged;
                numSoThang.ValueChanged += numSoThang_ValueChanged;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }

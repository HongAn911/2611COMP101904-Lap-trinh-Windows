using System.Globalization;

namespace Lab05
{
    public partial class FrmDangKyKhoaHoc : Form
    {
        private const int SoThangToiThieu = 1;
        private const int SoThangToiDa = 12;

        private static readonly CultureInfo CultureVN = CultureInfo.GetCultureInfo("vi-VN");

        // Danh sách khóa học theo đề bài
        private static readonly KhoaHocInfo[] DanhSachKhoaHoc =
        {
            new("C# WinForms cơ bản", 800_000),
            new("SQL Server cơ bản", 700_000),
            new("Web Frontend cơ bản", 750_000),
            new("Lập trình Python cơ bản", 650_000),
        };

        public FrmDangKyKhoaHoc()
        {
            InitializeComponent();
        }

        #region Hàm hỗ trợ

        private KhoaHocInfo LayKhoaHocDangChon() => cboKhoaHoc.SelectedItem as KhoaHocInfo;

        private static string DinhDangTien(long soTien) =>
            soTien.ToString("N0", CultureVN) + " VNĐ";

        private long TinhHocPhi()
        {
            var khoaHoc = LayKhoaHocDangChon();
            if (khoaHoc == null) return 0;
            return (long)khoaHoc.HocPhiMoiThang * (int)numSoThang.Value;
        }

        private void HienThiHocPhi() => lblTongTien.Text = DinhDangTien(TinhHocPhi());

        private string LayHinhThucHoc() => radOnline.Checked ? "Online" : "Trực tiếp";

        private static void BaoLoi(string noiDung, Control controlLoi)
        {
            MessageBox.Show(noiDung, "Dữ liệu chưa hợp lệ",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            controlLoi.Focus();
        }

        // Trả về true nếu dữ liệu hợp lệ; ngược lại báo lỗi và dừng ở control sai
        private bool KiemTraDuLieu()
        {
            if (txtHoTen.Text.Trim().Length == 0)
            {
                BaoLoi("Vui lòng nhập họ tên học viên.", txtHoTen);
                return false;
            }
            if (txtSoDienThoai.Text.Trim().Length == 0)
            {
                BaoLoi("Vui lòng nhập số điện thoại.", txtSoDienThoai);
                return false;
            }
            if (LayKhoaHocDangChon() == null)
            {
                BaoLoi("Vui lòng chọn khóa học.", cboKhoaHoc);
                return false;
            }
            return true;
        }

        private string TaoNoiDungPhieu(KhoaHocInfo khoaHoc)
        {
            var cacDong = new[]
            {
                $"Họ tên: {txtHoTen.Text.Trim()}",
                $"Số điện thoại: {txtSoDienThoai.Text.Trim()}",
                $"Ngày sinh: {dtpNgaySinh.Value:dd/MM/yyyy}",
                $"Khóa học: {khoaHoc.Ten}",
                $"Hình thức học: {LayHinhThucHoc()}",
                $"Số tháng: {numSoThang.Value}",
                $"Tổng tiền: {DinhDangTien(TinhHocPhi())}",
                $"Nhận email thông báo: {(chkNhanEmail.Checked ? "Có" : "Không")}",
            };
            return string.Join(Environment.NewLine, cacDong);
        }

        private void DatLaiGiaTriMacDinh()
        {
            txtHoTen.Clear();
            txtSoDienThoai.Clear();
            dtpNgaySinh.Value = DateTime.Today;
            chkNhanEmail.Checked = false;
            cboKhoaHoc.SelectedIndex = -1;   // -1: chưa chọn khóa học nào
            radOnline.Checked = true;
            numSoThang.Value = SoThangToiThieu;
            HienThiHocPhi();
        }

        #endregion

        #region Sự kiện

        private void FrmDangKyKhoaHoc_Load(object sender, EventArgs e)
        {
            cboKhoaHoc.Items.AddRange(DanhSachKhoaHoc);
            numSoThang.Minimum = SoThangToiThieu;
            numSoThang.Maximum = SoThangToiDa;
            DatLaiGiaTriMacDinh();
        }

        private void cboKhoaHoc_SelectedIndexChanged(object sender, EventArgs e) => HienThiHocPhi();

        private void numSoThang_ValueChanged(object sender, EventArgs e) => HienThiHocPhi();

        private void btnDangKy_Click(object sender, EventArgs e)
        {
            if (!KiemTraDuLieu()) return;

            var khoaHoc = LayKhoaHocDangChon();
            MessageBox.Show(TaoNoiDungPhieu(khoaHoc), "Phiếu đăng ký khóa học",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            DatLaiGiaTriMacDinh();
            txtHoTen.Focus();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            var traLoi = MessageBox.Show("Bạn có muốn thoát chương trình không?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (traLoi == DialogResult.Yes)
            {
                Close();
            }
        }

        #endregion
    }
}

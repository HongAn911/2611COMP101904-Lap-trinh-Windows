using EduManager.BLL;
using EduManager.Models;

namespace EduManager.GUI
{
    /// <summary>
    /// Form Quản lý môn học (lớp GUI): chỉ nhận dữ liệu, gọi BLL và hiển thị kết quả.
    /// Không viết SQL, không chứa logic kiểm tra nghiệp vụ.
    /// </summary>
    public partial class FrmMonHoc : Form
    {
        private readonly MonHocBLL _bll = new MonHocBLL();

        /// <summary>true khi đang chọn một môn học trên lưới (chế độ sửa/xóa).</summary>
        private bool _dangChonDong;

        public FrmMonHoc()
        {
            InitializeComponent();
            dgvMonHoc.AutoGenerateColumns = false;   // dùng các cột đã thiết kế sẵn
            colSoTinChi.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colTrangThai.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colSoTinChi.HeaderCell.Style.Padding = new Padding(0);
            colTrangThai.HeaderCell.Style.Padding = new Padding(0);
        }

        // ================== Màu sắc giao diện ==================

        private static readonly Color MauVien = Color.FromArgb(203, 213, 225);
        private static readonly Color MauVienFocus = Color.FromArgb(37, 99, 235);
        private static readonly Color MauVienThe = Color.FromArgb(226, 232, 240);
        private static readonly Color MauNenKhoa = Color.FromArgb(241, 245, 249);

        /// <summary>Màu của một nút: màu chính, màu khi rê chuột, màu nền và chữ khi chưa dùng được.</summary>
        private readonly record struct MauNut(Color Chinh, Color Hover, Color NenNhat, Color ChuNhat);

        private static readonly MauNut MauThem = new(Color.FromArgb(22, 163, 74), Color.FromArgb(21, 128, 61),
                                                     Color.FromArgb(236, 253, 243), Color.FromArgb(110, 190, 140));
        private static readonly MauNut MauSua = new(Color.FromArgb(37, 99, 235), Color.FromArgb(29, 78, 216),
                                                    Color.FromArgb(239, 246, 255), Color.FromArgb(130, 165, 235));
        private static readonly MauNut MauXoa = new(Color.FromArgb(220, 38, 38), Color.FromArgb(185, 28, 28),
                                                    Color.FromArgb(254, 242, 242), Color.FromArgb(235, 140, 140));

        /// <summary>Vẽ viền mảnh cho khung chứa ô nhập; viền xanh đậm hơn khi ô đang được nhập.</summary>
        private void KhungNhap_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Panel p) return;
            bool focus = p.ContainsFocus;
            using var pen = new Pen(focus ? MauVienFocus : MauVien, focus ? 2 : 1);
            var r = focus
                ? new Rectangle(1, 1, p.Width - 2, p.Height - 2)
                : new Rectangle(0, 0, p.Width - 1, p.Height - 1);
            e.Graphics.DrawRectangle(pen, r);
        }

        /// <summary>Bấm vào khung thì đưa con trỏ vào ô nhập bên trong.</summary>
        private void KhungNhap_Click(object? sender, EventArgs e)
        {
            if (sender is Panel p && p.Controls.Count > 0) p.Controls[0].Focus();
        }

        /// <summary>Ô nhập được/mất focus thì vẽ lại viền khung chứa nó.</summary>
        private void O_DoiFocus(object? sender, EventArgs e)
        {
            (sender as Control)?.Parent?.Invalidate();
        }

        /// <summary>Vẽ viền mảnh cho hai khung thẻ trắng.</summary>
        private void The_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Panel p) return;
            using var pen = new Pen(MauVienThe);
            e.Graphics.DrawRectangle(pen, 0, 0, p.Width - 1, p.Height - 1);
        }

        private void VeLai_Resize(object? sender, EventArgs e)
        {
            (sender as Control)?.Invalidate();
        }

        private void FrmMonHoc_Shown(object sender, EventArgs e)
        {
            // Khi form hiện lên, bỏ chọn dòng đầu tiên để đúng chế độ "Thêm mới"
            dgvMonHoc.ClearSelection();
            dgvMonHoc.CurrentCell = null;
            txtMaMonHoc.Focus();
        }

        // ================== Sự kiện Form ==================

        private void FrmMonHoc_Load(object sender, EventArgs e)
        {
            nudSoTinChi.Minimum = MonHocBLL.SoTinChiMin;
            nudSoTinChi.Maximum = MonHocBLL.SoTinChiMax;
            LamMoiForm();
            NapDanhSach(() => _bll.LayDanhSach());
        }

        // ================== Sự kiện Button ==================

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (_dangChonDong)
            {
                ThongBaoCanhBao("Đang ở chế độ Sửa / Xóa.\nBấm \"Làm mới\" để chuyển sang chế độ thêm môn học mới.");
                return;
            }

            ThucHien(() =>
            {
                var monHoc = LayDuLieuTuForm();
                _bll.Them(monHoc);
                ThongBaoThanhCong($"Đã thêm môn học \"{monHoc.MaMonHoc}\".");
                LamMoiForm();
                NapDanhSach(() => _bll.LayDanhSach());
                ChonDongTheoMa(monHoc.MaMonHoc);
            });
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!_dangChonDong)
            {
                ThongBaoCanhBao("Vui lòng chọn môn học cần sửa trên danh sách.");
                return;
            }

            ThucHien(() =>
            {
                var monHoc = LayDuLieuTuForm();
                _bll.Sua(monHoc);
                ThongBaoThanhCong($"Đã cập nhật môn học \"{monHoc.MaMonHoc}\".");
                NapDanhSach(() => _bll.TimKiem(txtTimKiem.Text));
                ChonDongTheoMa(monHoc.MaMonHoc);
            });
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!_dangChonDong)
            {
                ThongBaoCanhBao("Vui lòng chọn môn học cần xóa trên danh sách.");
                return;
            }

            string ma = txtMaMonHoc.Text.Trim();
            string ten = txtTenMonHoc.Text.Trim();

            var traLoi = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa môn học:\n\n{ma} - {ten} ?\n\nThao tác này không thể hoàn tác.",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);

            if (traLoi != DialogResult.Yes) return;

            ThucHien(() =>
            {
                _bll.Xoa(ma);
                ThongBaoThanhCong($"Đã xóa môn học \"{ma}\".");
                LamMoiForm();
                NapDanhSach(() => _bll.TimKiem(txtTimKiem.Text));
            });
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Clear();
            LamMoiForm();
            NapDanhSach(() => _bll.LayDanhSach());
            lblTrangThai.Text = "Đã làm mới form và tải lại danh sách.";
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            LamMoiForm();
            NapDanhSach(() => _bll.TimKiem(txtTimKiem.Text));

            if (txtTimKiem.Text.Trim().Length > 0)
                lblTrangThai.Text = $"Tìm thấy {dgvMonHoc.Rows.Count} môn học với từ khóa \"{txtTimKiem.Text.Trim()}\".";
        }

        private void txtTimKiem_KeyDown(object sender, KeyEventArgs e)
        {
            // Nhấn Enter trong ô tìm kiếm = bấm nút Tìm kiếm
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                btnTimKiem.PerformClick();
            }
        }

        // ================== Sự kiện DataGridView ==================

        private void dgvMonHoc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) HienThiDongDangChon();
        }

        private void dgvMonHoc_SelectionChanged(object sender, EventArgs e)
        {
            // Chỉ xử lý khi người dùng đang thao tác trên lưới (chuột / phím mũi tên),
            // tránh tự chọn dòng đầu khi vừa nạp dữ liệu.
            if (dgvMonHoc.Focused) HienThiDongDangChon();
        }

        // ================== Hàm hỗ trợ ==================

        /// <summary>Đọc dữ liệu từ các control nhập liệu thành đối tượng MonHoc.</summary>
        private MonHoc LayDuLieuTuForm()
        {
            return new MonHoc
            {
                MaMonHoc = txtMaMonHoc.Text,
                TenMonHoc = txtTenMonHoc.Text,
                SoTinChi = (int)nudSoTinChi.Value,
                TrangThai = chkTrangThai.Checked
            };
        }

        /// <summary>Đổ dữ liệu của dòng đang chọn lên các control nhập liệu.</summary>
        private void HienThiDongDangChon()
        {
            if (dgvMonHoc.CurrentRow?.DataBoundItem is not MonHoc mh) return;

            txtMaMonHoc.Text = mh.MaMonHoc;
            txtTenMonHoc.Text = mh.TenMonHoc;
            nudSoTinChi.Value = Math.Clamp(mh.SoTinChi, MonHocBLL.SoTinChiMin, MonHocBLL.SoTinChiMax);
            chkTrangThai.Checked = mh.TrangThai;

            DatCheDo(dangChonDong: true);
            lblTrangThai.Text = $"Đang chọn: {mh.MaMonHoc} - {mh.TenMonHoc}";
        }

        /// <summary>Xóa trắng các ô nhập, quay về chế độ thêm mới.</summary>
        private void LamMoiForm()
        {
            txtMaMonHoc.Clear();
            txtTenMonHoc.Clear();
            nudSoTinChi.Value = 3;
            chkTrangThai.Checked = true;
            dgvMonHoc.ClearSelection();
            DatCheDo(dangChonDong: false);
            txtMaMonHoc.Focus();
        }

        /// <summary>
        /// Chế độ thêm mới: được nhập mã, bật nút Thêm.
        /// Chế độ đã chọn dòng: khóa mã (khóa chính), bật nút Sửa / Xóa.
        /// </summary>
        private void DatCheDo(bool dangChonDong)
        {
            _dangChonDong = dangChonDong;
            txtMaMonHoc.ReadOnly = dangChonDong;
            // Ô mã bị khóa: nền xám nhạt cả khung lẫn ô
            Color nenMa = dangChonDong ? MauNenKhoa : Color.White;
            txtMaMonHoc.BackColor = nenMa;
            pnlMaMonHoc.BackColor = nenMa;
            txtMaMonHoc.Cursor = dangChonDong ? Cursors.No : Cursors.IBeam;

            BatTatNut(btnThem, !dangChonDong, MauThem);
            BatTatNut(btnSua, dangChonDong, MauSua);
            BatTatNut(btnXoa, dangChonDong, MauXoa);
            lblCheDo.Text = dangChonDong ? "●  Chế độ: Sửa / Xóa" : "●  Chế độ: Thêm mới";
            lblCheDo.ForeColor = dangChonDong ? Color.FromArgb(217, 119, 6) : Color.FromArgb(22, 163, 74);
        }

        /// <summary>
        /// Đổi kiểu hiển thị nút. Không dùng Enabled = false vì Windows sẽ tô chữ xám đục;
        /// thay vào đó nút "chưa dùng được" có nền và chữ nhạt cùng tông màu,
        /// còn sự kiện Click đã tự kiểm tra chế độ trước khi xử lý.
        /// </summary>
        private static void BatTatNut(Button nut, bool dungDuoc, MauNut mau)
        {
            nut.BackColor = dungDuoc ? mau.Chinh : mau.NenNhat;
            nut.ForeColor = dungDuoc ? Color.White : mau.ChuNhat;
            nut.FlatAppearance.MouseOverBackColor = dungDuoc ? mau.Hover : mau.NenNhat;
            nut.FlatAppearance.MouseDownBackColor = dungDuoc ? mau.Hover : mau.NenNhat;
            nut.Cursor = dungDuoc ? Cursors.Hand : Cursors.Default;
        }

        /// <summary>Lấy danh sách từ BLL và gán vào DataGridView.</summary>
        private void NapDanhSach(Func<List<MonHoc>> layDuLieu)
        {
            ThucHien(() =>
            {
                var ds = layDuLieu();
                dgvMonHoc.DataSource = null;
                dgvMonHoc.DataSource = ds;
                dgvMonHoc.ClearSelection();

                int conSuDung = ds.Count(m => m.TrangThai);
                lblTongSo.Text = $"Tổng: {ds.Count} môn học  |  Còn sử dụng: {conSuDung}  |  Ngừng: {ds.Count - conSuDung}";
                lblTrangThai.Text = "Sẵn sàng.";
            });
        }

        /// <summary>Chọn và cuộn tới dòng có mã môn học tương ứng.</summary>
        private void ChonDongTheoMa(string ma)
        {
            foreach (DataGridViewRow row in dgvMonHoc.Rows)
            {
                if (row.DataBoundItem is MonHoc mh && mh.MaMonHoc == ma)
                {
                    dgvMonHoc.CurrentCell = row.Cells[0];
                    row.Selected = true;
                    dgvMonHoc.FirstDisplayedScrollingRowIndex = row.Index;
                    HienThiDongDangChon();
                    return;
                }
            }
        }

        /// <summary>Bọc lời gọi BLL, hiển thị lỗi thân thiện thay vì làm sập chương trình.</summary>
        private void ThucHien(Action action)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                action();
            }
            catch (BusinessException ex)
            {
                ThongBaoCanhBao(ex.Message);
            }
            catch (Exception ex)
            {
                lblTrangThai.Text = "Lỗi kết nối cơ sở dữ liệu.";
                MessageBox.Show(
                    "Không thể kết nối hoặc truy vấn cơ sở dữ liệu.\n" +
                    "Hãy kiểm tra SQL Server đã chạy, database EduManagerDB đã được tạo " +
                    "và chuỗi kết nối trong Data/EduManagerContext.cs.\n\nChi tiết: " +
                    (ex.InnerException?.Message ?? ex.Message),
                    "Lỗi hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void ThongBaoThanhCong(string msg)
        {
            lblTrangThai.Text = msg;
            MessageBox.Show(msg, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ThongBaoCanhBao(string msg)
        {
            lblTrangThai.Text = msg;
            MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}

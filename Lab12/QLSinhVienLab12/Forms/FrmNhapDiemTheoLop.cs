using System.Data;
using System.Globalization;
using QLSinhVienLab12.DAL;

namespace QLSinhVienLab12.Forms
{
    public partial class FrmNhapDiemTheoLop : Form
    {
        private readonly KetQuaDAL ketQuaDAL = new KetQuaDAL();
        private readonly BindingSource ketQuaSource = new BindingSource();

        // Lớp/môn của danh sách ĐANG hiển thị (tránh lưu nhầm khi người dùng đổi ComboBox sau khi tải)
        private string maLopDangTai = "";
        private string maMonDangTai = "";

        public FrmNhapDiemTheoLop()
        {
            InitializeComponent();
        }

        // ============================ LOAD FORM ============================
        private void FrmNhapDiemTheoLop_Load(object? sender, EventArgs e)
        {
            dgvKetQua.DataSource = ketQuaSource;
            // Mỗi khi lưới nạp/lọc lại dữ liệu -> đánh dấu ngay các dòng chưa có điểm hợp lệ
            dgvKetQua.DataBindingComplete += (s, args) => CapNhatDanhDauLoi();
            ketQuaSource.ListChanged += (s, args) => CapNhatThongKe();
            LoadComboBox();
        }

        private void LoadComboBox()
        {
            try
            {
                // Đặt DisplayMember/ValueMember TRƯỚC khi gán DataSource
                cboLop.DisplayMember = "TenLop";
                cboLop.ValueMember = "MaLop";
                cboLop.DataSource = ketQuaDAL.GetLop();

                cboMonHoc.DisplayMember = "TenMon";
                cboMonHoc.ValueMember = "MaMon";
                cboMonHoc.DataSource = ketQuaDAL.GetMonHoc();

                CapNhatTrangThai("Đã tải danh sách lớp và môn học. Chọn lớp, môn rồi bấm \"Tải danh sách\".");
            }
            catch (Exception ex)
            {
                CapNhatTrangThai("Lỗi kết nối cơ sở dữ liệu.");
                MessageBox.Show("Không kết nối được database QLSinhVienLab12.\n" +
                                "Hãy chạy script SQL và kiểm tra ConnectionString trong DAL/Database.cs.\n\n" +
                                ex.Message, "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================ TẢI DANH SÁCH ============================
        private void btnTaiDanhSach_Click(object? sender, EventArgs e)
        {
            string maLop = cboLop.SelectedValue?.ToString() ?? "";
            string maMon = cboMonHoc.SelectedValue?.ToString() ?? "";

            if (maLop.Length == 0 || maMon.Length == 0)
            {
                MessageBox.Show("Vui lòng chọn lớp và môn học.", "Thiếu thông tin",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                HienThiDanhSach(maLop, maMon);
                CapNhatTrangThai($"Đã tải {ketQuaSource.Count} sinh viên của lớp {cboLop.Text} - môn {cboMonHoc.Text}.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không tải được danh sách: " + ex.Message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HienThiDanhSach(string maLop, string maMon)
        {
            DataTable table = ketQuaDAL.GetKetQuaByLopMon(maLop, maMon);

            maLopDangTai = maLop;
            maMonDangTai = maMon;

            txtTim.Clear();
            ketQuaSource.Filter = null;
            ketQuaSource.DataSource = table;      // BindingSource là cầu nối DataTable <-> DataGridView

            bool coDuLieu = table.Rows.Count > 0;
            btnLuuTatCa.Enabled = coDuLieu;
            txtTim.Enabled = coDuLieu;
            CapNhatThongKe();
        }

        // Đổi lớp/môn sau khi đã tải -> danh sách cũ không còn đúng ngữ cảnh nên xoá đi
        private void CboLopMon_SelectionChangeCommitted(object? sender, EventArgs e)
        {
            if (ketQuaSource.DataSource == null) return;

            ketQuaSource.DataSource = null;
            maLopDangTai = maMonDangTai = "";
            btnLuuTatCa.Enabled = false;
            txtTim.Enabled = false;
            txtTim.Clear();
            CapNhatThongKe();
            CapNhatTrangThai("Đã đổi lớp/môn. Bấm \"Tải danh sách\" để tải lại.");
        }

        // ============================ LƯU TẤT CẢ ============================
        private void btnLuuTatCa_Click(object? sender, EventArgs e)
        {
            if (ketQuaSource.DataSource is not DataTable table || maMonDangTai.Length == 0) return;

            // Đẩy giá trị ô đang gõ dở vào DataTable
            if (!dgvKetQua.EndEdit())
            {
                CapNhatTrangThai("Ô đang sửa chưa hợp lệ - hãy sửa lại hoặc nhấn Esc.");
                return;
            }
            ketQuaSource.EndEdit();

            // 1) Kiểm tra TOÀN BỘ dòng (kể cả dòng bị lọc ẩn) trước khi chạm vào database
            List<string> loi = KiemTraDuLieu(table);
            if (loi.Count > 0)
            {
                CapNhatTrangThai($"Có {loi.Count} dòng lỗi - chưa lưu gì cả.");
                MessageBox.Show("Không thể lưu vì dữ liệu chưa hợp lệ:\n\n" +
                                string.Join("\n", loi.Take(8)) +
                                (loi.Count > 8 ? $"\n... và {loi.Count - 8} lỗi khác." : ""),
                                "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2) Lưu bằng transaction; lỗi ở bất kỳ dòng nào -> rollback toàn bộ
            try
            {
                int soDong = ketQuaDAL.SaveAll(maMonDangTai, table);
                table.AcceptChanges();
                CapNhatTrangThai($"Đã lưu thành công {soDong} dòng.");
                MessageBox.Show($"Đã lưu thành công {soDong} dòng.", "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                CapNhatTrangThai("Lưu thất bại - đã rollback toàn bộ.");
                MessageBox.Show("Không thể lưu dữ liệu. Toàn bộ thao tác đã được hủy (rollback).\n\n" + ex.Message,
                                "Lỗi khi lưu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================ VALIDATION ============================
        // Trả về lỗi của 1 giá trị điểm (null nếu hợp lệ). Dùng chung cho nhập liệu và trước khi lưu.
        private static string? KiemTraDiem(object? giaTri)
        {
            if (giaTri == null || giaTri == DBNull.Value || string.IsNullOrWhiteSpace(giaTri.ToString()))
                return "Điểm không được để trống.";

            if (!TryParseDiem(giaTri.ToString()!, out double diem))
                return "Điểm phải là một số.";

            if (diem < 0 || diem > 10)
                return "Điểm phải nằm trong khoảng từ 0 đến 10.";

            return null;
        }

        // Chấp nhận cả "8.5" lẫn "8,5" bất kể cấu hình vùng của Windows
        private static bool TryParseDiem(string text, out double diem)
        {
            text = text.Trim().Replace(',', '.');
            return double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out diem)
                   && !double.IsNaN(diem) && !double.IsInfinity(diem);
        }

        // Kiểm tra TOÀN BỘ DataTable (kể cả dòng đang bị lọc ẩn), trả về danh sách lỗi
        private List<string> KiemTraDuLieu(DataTable table)
        {
            var danhSachLoi = new List<string>();

            foreach (DataRow row in table.Rows)
            {
                string? loi = KiemTraDiem(row["Diem"]);
                if (loi == null) continue;

                danhSachLoi.Add($"- {row["MaSV"]} ({row["HoTen"]}): {loi}");
            }

            CapNhatDanhDauLoi();

            // Đưa con trỏ tới ô lỗi đầu tiên
            foreach (DataGridViewRow gridRow in dgvKetQua.Rows)
            {
                if (!string.IsNullOrEmpty(gridRow.Cells[colDiem.Index].ErrorText))
                {
                    dgvKetQua.CurrentCell = gridRow.Cells[colDiem.Index];
                    break;
                }
            }
            return danhSachLoi;
        }

        // Hiện dấu X đỏ + tô hồng cả dòng cho mọi sinh viên chưa có điểm hợp lệ.
        // Gọi lại sau khi tải danh sách, lọc, và sau mỗi lần sửa ô.
        private void CapNhatDanhDauLoi()
        {
            foreach (DataGridViewRow gridRow in dgvKetQua.Rows)
            {
                object? giaTri = (gridRow.DataBoundItem as DataRowView)?["Diem"];
                string? loi = KiemTraDiem(giaTri);

                gridRow.Cells[colDiem.Index].ErrorText = loi ?? string.Empty;
                gridRow.DefaultCellStyle.BackColor = loi == null ? Color.Empty : Color.FromArgb(255, 228, 228);
            }
        }

        // ---- Sự kiện của DataGridView ----

        // Kiểm tra ngay khi người dùng rời khỏi ô Điểm
        private void dgvKetQua_CellValidating(object? sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex != colDiem.Index || !dgvKetQua.IsCurrentCellInEditMode) return;

            string? loi = KiemTraDiem(e.FormattedValue);
            if (loi != null)
            {
                dgvKetQua.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = loi;
                CapNhatTrangThai(loi + " (nhấn Esc để hủy chỉnh sửa)");
                e.Cancel = true;                 // giữ con trỏ lại ô lỗi cho tới khi sửa đúng

                MessageBox.Show(loi + "\n\nHãy nhập lại, hoặc nhấn Esc để hủy chỉnh sửa ô này.",
                                "Điểm không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Chuyển chuỗi người dùng gõ ("8,5" hoặc "8.5") thành double trước khi ghi vào DataTable
        private void dgvKetQua_CellParsing(object? sender, DataGridViewCellParsingEventArgs e)
        {
            if (e.ColumnIndex != colDiem.Index) return;

            if (TryParseDiem(e.Value?.ToString() ?? "", out double diem))
            {
                e.Value = diem;
                e.ParsingApplied = true;
            }
        }

        private void dgvKetQua_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            CapNhatDanhDauLoi();
            CapNhatTrangThai("Đã sửa dữ liệu - nhớ bấm \"Lưu tất cả\" để ghi xuống database.");
        }

        // Không để WinForms bật hộp thoại lỗi mặc định
        private void dgvKetQua_DataError(object? sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
            CapNhatTrangThai("Giá trị nhập không hợp lệ.");
        }

        // ============================ MỞ RỘNG ============================
        // Lọc theo Mã SV / Họ tên bằng BindingSource.Filter
        private void txtTim_TextChanged(object? sender, EventArgs e)
        {
            if (ketQuaSource.DataSource == null) return;

            string tuKhoa = txtTim.Text.Trim();
            if (tuKhoa.Length == 0)
            {
                ketQuaSource.RemoveFilter();
                return;
            }

            // Escape ký tự đặc biệt của biểu thức Filter / LIKE
            string an = tuKhoa.Replace("'", "''").Replace("[", "[[]").Replace("%", "[%]").Replace("*", "[*]");
            ketQuaSource.Filter = $"MaSV LIKE '%{an}%' OR HoTen LIKE '%{an}%'";
            CapNhatTrangThai($"Tìm thấy {ketQuaSource.Count} sinh viên.");
        }

        // Thống kê trên các dòng đã có điểm hợp lệ
        private void CapNhatThongKe()
        {
            if (ketQuaSource.DataSource is not DataTable table || table.Rows.Count == 0)
            {
                lblThongKe.Text = "Thống kê: (chưa có dữ liệu)";
                return;
            }

            var diemList = new List<double>();
            foreach (DataRow row in table.Rows)
                if (row["Diem"] != DBNull.Value) diemList.Add(Convert.ToDouble(row["Diem"]));

            lblThongKe.Text = diemList.Count == 0
                ? $"Thống kê: {table.Rows.Count} sinh viên - chưa nhập điểm"
                : $"Thống kê: {table.Rows.Count} sinh viên | đã nhập {diemList.Count} | " +
                  $"TB {diemList.Average():0.00} | cao nhất {diemList.Max():0.0} | thấp nhất {diemList.Min():0.0}";
        }

        private void CapNhatTrangThai(string noiDung)
        {
            tsslTrangThai.Text = noiDung;
        }
    }
}
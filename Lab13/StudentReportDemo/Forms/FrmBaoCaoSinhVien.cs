using StudentReportDemo.Models;
using System.Globalization;
using System.Text;

namespace StudentReportDemo.Forms
{
    public partial class FrmBaoCaoSinhVien : Form
    {
        // Nguồn dữ liệu gốc
        private List<SinhVien> danhSachSinhVien = new List<SinhVien>();

        // Kết quả đang hiển thị trên lưới (dùng lại khi xuất file)
        private List<object> duLieuDangHienThi = new List<object>();

        // Cờ chặn các sự kiện SelectedIndexChanged/TextChanged chạy khi đang nạp ComboBox
        private bool dangKhoiTao = true;

        // Tiêu đề tiếng Việt cho các cột của DataGridView
        private readonly Dictionary<string, string> tieuDeCot = new Dictionary<string, string>
        {
            { "MaSV", "Mã SV" },
            { "HoTen", "Họ tên" },
            { "MaLop", "Mã lớp" },
            { "TenLop", "Tên lớp" },
            { "Diem", "Điểm TB" },
            { "KetQua", "Kết quả" },
            { "SoLuong", "Số lượng" },
            { "SoDat", "Số đạt" },
            { "SoKhongDat", "Số không đạt" },
            { "DiemTrungBinh", "Điểm trung bình" }
        };

        public FrmBaoCaoSinhVien()
        {
            InitializeComponent();
            TrangTriGiaoDien();
        }

        private void FrmBaoCaoSinhVien_Load(object sender, EventArgs e)
        {
            TaoDuLieuMau();
            LoadComboBox();
            dangKhoiTao = false;
            XemBaoCao(hienThongBao: false);
        }

        #region 1. Tạo dữ liệu mẫu

        private void TaoDuLieuMau()
        {
            danhSachSinhVien = new List<SinhVien>
            {
                new SinhVien { MaSV = "SV001", HoTen = "Nguyễn Văn An",   MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 8.2 },
                new SinhVien { MaSV = "SV002", HoTen = "Trần Thị Bình",   MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 6.5 },
                new SinhVien { MaSV = "SV003", HoTen = "Lê Minh Cường",   MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 4.8 },
                new SinhVien { MaSV = "SV004", HoTen = "Phạm Thanh Dung", MaLop = "CTK47A", TenLop = "CNTT K47A", Diem = 9.1 },
                new SinhVien { MaSV = "SV005", HoTen = "Hoàng Quốc Huy",  MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 7.4 },
                new SinhVien { MaSV = "SV006", HoTen = "Võ Gia Khang",    MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 3.9 },
                new SinhVien { MaSV = "SV007", HoTen = "Đặng Minh Khôi",  MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 5.5 },
                new SinhVien { MaSV = "SV008", HoTen = "Bùi Thảo Linh",   MaLop = "CTK47B", TenLop = "CNTT K47B", Diem = 8.0 },
                new SinhVien { MaSV = "SV009", HoTen = "Ngô Tuấn Minh",   MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 6.0 },
                new SinhVien { MaSV = "SV010", HoTen = "Đỗ Bảo Ngọc",     MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 9.3 },
                new SinhVien { MaSV = "SV011", HoTen = "Huỳnh Gia Phúc",  MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 4.2 },
                new SinhVien { MaSV = "SV012", HoTen = "Mai Anh Thư",     MaLop = "CTK48A", TenLop = "CNTT K48A", Diem = 7.8 }
            };
        }

        #endregion

        #region 2. Load ComboBox

        private void LoadComboBox()
        {
            // LINQ: Select lấy mã + tên lớp, Distinct bỏ lớp trùng, OrderBy sắp xếp
            var dsLop = danhSachSinhVien
                .Select(sv => new { sv.MaLop, sv.TenLop })
                .Distinct()
                .OrderBy(lop => lop.MaLop)
                .ToList();

            // Gán DisplayMember/ValueMember TRƯỚC DataSource để SelectedValue đúng ngay từ đầu
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
            cboLop.DataSource = dsLop;

            cboKetQua.Items.Clear();
            cboKetQua.Items.Add("Tất cả");
            cboKetQua.Items.Add("Đạt");
            cboKetQua.Items.Add("Không đạt");
            cboKetQua.SelectedIndex = 0;

            cboSapXep.Items.Clear();
            cboSapXep.Items.Add("Điểm giảm dần");
            cboSapXep.Items.Add("Điểm tăng dần");
            cboSapXep.SelectedIndex = 0;
        }

        #endregion

        #region 3. Xem báo cáo (lọc + sắp xếp + chọn dữ liệu bằng LINQ)

        /// <param name="hienThongBao">
        /// true: hiện MessageBox khi không có dữ liệu (bấm nút Xem báo cáo).
        /// false: chỉ báo trên StatusStrip (khi tự lọc lúc gõ từ khóa/đổi ComboBox),
        /// tránh bật hộp thoại liên tục mỗi lần gõ phím.
        /// </param>
        private void XemBaoCao(bool hienThongBao = true)
        {
            if (cboLop.SelectedValue == null) return;

            string maLop = cboLop.SelectedValue.ToString();
            string ketQua = cboKetQua.SelectedItem?.ToString() ?? "Tất cả";
            string tuKhoa = txtTuKhoa.Text.Trim().ToLower();

            // Where: lọc theo lớp
            var query = danhSachSinhVien.Where(sv => sv.MaLop == maLop);

            // Where: lọc theo kết quả học tập
            if (ketQua == "Đạt")
            {
                query = query.Where(sv => sv.Diem >= 5);
            }
            else if (ketQua == "Không đạt")
            {
                query = query.Where(sv => sv.Diem < 5);
            }

            // Where: tìm theo mã hoặc họ tên
            if (!string.IsNullOrWhiteSpace(tuKhoa))
            {
                query = query.Where(sv =>
                    sv.MaSV.ToLower().Contains(tuKhoa) ||
                    sv.HoTen.ToLower().Contains(tuKhoa));
            }

            // Sắp xếp theo lựa chọn của người dùng:
            //   OrderBy           -> điểm tăng dần
            //   OrderByDescending -> điểm giảm dần (mặc định)
            bool tangDan = cboSapXep.SelectedIndex == 1;
            IOrderedEnumerable<SinhVien> daSapXep = tangDan
                ? query.OrderBy(sv => sv.Diem)
                : query.OrderByDescending(sv => sv.Diem);

            // ThenBy: cùng điểm thì theo họ tên
            // Select: chỉ lấy các cột cần hiển thị; ToList: thực thi truy vấn trước khi binding
            var baoCao = daSapXep
                .ThenBy(sv => sv.HoTen)
                .Select(sv => new
                {
                    sv.MaSV,
                    sv.HoTen,
                    sv.TenLop,
                    sv.Diem,
                    sv.KetQua
                })
                .ToList();

            dgvBaoCao.DataSource = baoCao;
            DinhDangLuoi();
            duLieuDangHienThi = baoCao.Cast<object>().ToList();

            CapNhatThongKe(baoCao.Count);

            if (baoCao.Count == 0 && hienThongBao)
            {
                MessageBox.Show("Không có sinh viên nào phù hợp với điều kiện lọc.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region 4. Cập nhật thống kê trên StatusStrip

        private void CapNhatThongKe(int soDongHienThi)
        {
            string maLop = cboLop.SelectedValue?.ToString() ?? "";

            var dsLop = danhSachSinhVien
                .Where(sv => sv.MaLop == maLop)
                .ToList();

            int tongSo = dsLop.Count;
            int soDat = dsLop.Count(sv => sv.Diem >= 5);
            int soKhongDat = dsLop.Count(sv => sv.Diem < 5);
            // Kiểm tra tongSo > 0 để tránh lỗi Average trên danh sách rỗng
            double diemTB = tongSo > 0 ? dsLop.Average(sv => sv.Diem) : 0;

            string thongBaoRong = soDongHienThi == 0 ? "  ⚠ Không có dữ liệu phù hợp" : "";

            lblThongKe.Text = $"Đang hiển thị: {soDongHienThi} | " +
                              $"Tổng lớp: {tongSo} | Đạt: {soDat} | " +
                              $"Không đạt: {soKhongDat} | ĐTB: {diemTB:0.00}" +
                              thongBaoRong;
        }

        #endregion

        #region 5. Thống kê theo lớp (GroupBy)

        private void ThongKeTheoLop()
        {
            // GroupBy gom sinh viên theo lớp, Select tạo dòng thống kê cho từng nhóm
            var thongKe = danhSachSinhVien
                .GroupBy(sv => new { sv.MaLop, sv.TenLop })
                .Select(g => new
                {
                    g.Key.MaLop,
                    g.Key.TenLop,
                    SoLuong = g.Count(),
                    SoDat = g.Count(sv => sv.Diem >= 5),
                    SoKhongDat = g.Count(sv => sv.Diem < 5),
                    DiemTrungBinh = Math.Round(g.Average(sv => sv.Diem), 2)
                })
                .OrderBy(x => x.MaLop)
                .ToList();

            if (thongKe.Count == 0)
            {
                MessageBox.Show("Chưa có dữ liệu sinh viên để thống kê.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvBaoCao.DataSource = thongKe;
            DinhDangLuoi();
            duLieuDangHienThi = thongKe.Cast<object>().ToList();

            int tongSV = thongKe.Sum(x => x.SoLuong);
            double diemTBChung = danhSachSinhVien.Average(sv => sv.Diem);
            lblThongKe.Text = $"Thống kê theo lớp: {thongKe.Count} lớp | " +
                              $"Tổng SV: {tongSV} | " +
                              $"Đạt: {thongKe.Sum(x => x.SoDat)} | " +
                              $"Không đạt: {thongKe.Sum(x => x.SoKhongDat)} | " +
                              $"ĐTB chung: {diemTBChung:0.00}";
        }

        #endregion

        #region 6. Xuất file CSV / TXT

        private void XuatFile()
        {
            if (dgvBaoCao.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Lưu báo cáo sinh viên";
            sfd.Filter = "CSV file (*.csv)|*.csv|Text file (*.txt)|*.txt";
            sfd.FileName = "BaoCaoSinhVien.csv";

            if (sfd.ShowDialog() != DialogResult.OK) return;

            try
            {
                bool laFileTxt = Path.GetExtension(sfd.FileName)
                    .Equals(".txt", StringComparison.OrdinalIgnoreCase);
                string phanCach = laFileTxt ? "\t" : ",";

                StringBuilder sb = new StringBuilder();

                if (laFileTxt)
                {
                    sb.AppendLine("BÁO CÁO DANH SÁCH SINH VIÊN");
                    sb.AppendLine($"Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}");
                    sb.AppendLine(lblThongKe.Text);
                    sb.AppendLine();
                }

                // Dòng tiêu đề
                var tieuDe = dgvBaoCao.Columns
                    .Cast<DataGridViewColumn>()
                    .Select(col => ChuanHoaGiaTri(col.HeaderText, laFileTxt));
                sb.AppendLine(string.Join(phanCach, tieuDe));

                // Các dòng dữ liệu
                foreach (DataGridViewRow row in dgvBaoCao.Rows)
                {
                    if (row.IsNewRow) continue;

                    var giaTri = row.Cells
                        .Cast<DataGridViewCell>()
                        .Select(cell => ChuanHoaGiaTri(ChuyenSangChuoi(cell.Value), laFileTxt));
                    sb.AppendLine(string.Join(phanCach, giaTri));
                }

                // UTF-8 có BOM để Excel đọc đúng tiếng Việt
                File.WriteAllText(sfd.FileName, sb.ToString(), new UTF8Encoding(true));

                MessageBox.Show($"Xuất file thành công:\n{sfd.FileName}", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Không ghi được file (có thể file đang được mở bởi chương trình khác).\n"
                    + ex.Message, "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException ex)
            {
                MessageBox.Show("Không có quyền ghi vào thư mục đã chọn.\n" + ex.Message,
                    "Lỗi xuất file", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất file: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Số thực luôn ghi theo dạng 8.2 (InvariantCulture). Nếu máy dùng định dạng
        /// tiếng Việt thì 8.2 sẽ thành "8,2" và làm lệch cột trong CSV.
        /// </summary>
        private static string ChuyenSangChuoi(object value)
        {
            if (value == null) return "";
            if (value is double d) return d.ToString("0.##", CultureInfo.InvariantCulture);
            return value.ToString();
        }

        /// <summary>
        /// CSV: giá trị có dấu phẩy hoặc dấu nháy kép thì bọc trong "..." theo chuẩn CSV.
        /// TXT: thay tab bằng khoảng trắng.
        /// </summary>
        private static string ChuanHoaGiaTri(string value, bool laFileTxt)
        {
            if (laFileTxt) return value.Replace("\t", " ");

            if (value.Contains(',') || value.Contains('"') || value.Contains('\n'))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }
            return value;
        }

        #endregion

        #region 7. Hàm phụ trợ hiển thị

        // Bảng màu dùng chung cho toàn Form
        private static readonly Color MauChinh = Color.FromArgb(13, 71, 161);      // xanh dương đậm
        private static readonly Color MauNen = Color.FromArgb(244, 247, 251);      // xám xanh rất nhạt
        private static readonly Color MauDongXenKe = Color.FromArgb(234, 242, 253); // xanh rất nhạt
        private static readonly Color MauDat = Color.FromArgb(46, 125, 50);        // xanh lá
        private static readonly Color MauKhongDat = Color.FromArgb(198, 40, 40);   // đỏ
        private static readonly Color MauNenKhongDat = Color.FromArgb(255, 235, 238); // hồng nhạt

        // Font in đậm dùng chung cho các ô được tô màu (tạo 1 lần, không tạo lại mỗi ô)
        private readonly Font fontDam = new Font("Segoe UI", 9F, FontStyle.Bold);

        /// <summary>
        /// Tô màu cho Form, nút bấm, DataGridView và StatusStrip.
        /// </summary>
        private void TrangTriGiaoDien()
        {
            BackColor = MauNen;

            // Khung điều kiện lọc
            pnlDieuKien.BackColor = Color.White;
            lblTieuDe.ForeColor = MauChinh;
            foreach (Label lbl in new[] { lblLop, lblKetQua, lblTuKhoa, lblSapXep })
            {
                lbl.ForeColor = Color.FromArgb(55, 71, 79);
                lbl.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            }

            // Nút bấm: mỗi nút một màu
            TaoMauNut(btnXemBaoCao, Color.FromArgb(25, 118, 210));  // xanh dương
            TaoMauNut(btnThongKe, Color.FromArgb(46, 125, 50));     // xanh lá
            TaoMauNut(btnXuatFile, Color.FromArgb(239, 108, 0));    // cam

            // DataGridView
            dgvBaoCao.BorderStyle = BorderStyle.None;
            dgvBaoCao.BackgroundColor = MauNen;
            dgvBaoCao.GridColor = Color.FromArgb(208, 215, 226);
            dgvBaoCao.EnableHeadersVisualStyles = false;   // bắt buộc để tô màu được tiêu đề cột
            dgvBaoCao.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvBaoCao.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBaoCao.ColumnHeadersHeight = 36;
            dgvBaoCao.ColumnHeadersDefaultCellStyle.BackColor = MauChinh;
            dgvBaoCao.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvBaoCao.ColumnHeadersDefaultCellStyle.SelectionBackColor = MauChinh;
            dgvBaoCao.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvBaoCao.RowTemplate.Height = 30;
            dgvBaoCao.DefaultCellStyle.SelectionBackColor = Color.FromArgb(187, 222, 251);
            dgvBaoCao.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvBaoCao.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            dgvBaoCao.AlternatingRowsDefaultCellStyle.BackColor = MauDongXenKe;
            dgvBaoCao.CellFormatting += dgvBaoCao_CellFormatting;

            // StatusStrip
            stsThongKe.BackColor = MauChinh;
            lblThongKe.ForeColor = Color.White;
            lblThongKe.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
        }

        private static void TaoMauNut(Button btn, Color mau)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = mau;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.FlatAppearance.MouseOverBackColor = ControlPaint.Dark(mau, 0.1F);
            btn.FlatAppearance.MouseDownBackColor = ControlPaint.Dark(mau, 0.25F);
        }

        /// <summary>
        /// Tô màu theo kết quả: "Đạt" chữ xanh lá, "Không đạt" chữ đỏ và nền hồng nhạt cả dòng.
        /// Ở bảng thống kê: cột "Số không đạt" chữ đỏ, "Số đạt" chữ xanh lá.
        /// </summary>
        private void dgvBaoCao_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string tenCot = dgvBaoCao.Columns[e.ColumnIndex].DataPropertyName;

            if (dgvBaoCao.Columns.Contains("KetQua"))
            {
                bool khongDat = dgvBaoCao.Rows[e.RowIndex].Cells["KetQua"].Value?.ToString() == "Không đạt";
                if (khongDat)
                {
                    e.CellStyle.BackColor = MauNenKhongDat;
                }

                if (tenCot == "KetQua")
                {
                    e.CellStyle.ForeColor = khongDat ? MauKhongDat : MauDat;
                    e.CellStyle.Font = fontDam;
                }
            }
            else if (tenCot == "SoDat")
            {
                e.CellStyle.ForeColor = MauDat;
                e.CellStyle.Font = fontDam;
            }
            else if (tenCot == "SoKhongDat")
            {
                e.CellStyle.ForeColor = MauKhongDat;
                e.CellStyle.Font = fontDam;
            }
        }

        private void DinhDangLuoi()
        {
            foreach (DataGridViewColumn col in dgvBaoCao.Columns)
            {
                if (tieuDeCot.TryGetValue(col.DataPropertyName, out string tieuDe))
                {
                    col.HeaderText = tieuDe;
                }

                if (col.DataPropertyName == "Diem" || col.DataPropertyName == "DiemTrungBinh")
                {
                    col.DefaultCellStyle.Format = "0.00";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            }
        }

        #endregion

        #region 8. Sự kiện

        private void btnXemBaoCao_Click(object sender, EventArgs e)
        {
            XemBaoCao();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            ThongKeTheoLop();
        }

        private void btnXuatFile_Click(object sender, EventArgs e)
        {
            XuatFile();
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangKhoiTao) return;
            if (cboLop.SelectedValue != null)
            {
                XemBaoCao(hienThongBao: false);
            }
        }

        private void cboKetQua_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangKhoiTao) return;
            XemBaoCao(hienThongBao: false);
        }

        private void cboSapXep_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dangKhoiTao) return;
            XemBaoCao(hienThongBao: false);
        }

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {
            if (dangKhoiTao) return;
            XemBaoCao(hienThongBao: false);
        }

        #endregion
    }
}

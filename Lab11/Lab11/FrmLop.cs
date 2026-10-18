using System.Data;
using Microsoft.Data.SqlClient;

namespace COMP1019_Buoi11_Lab11
{
    public partial class FrmLop : Form
    {
        // Máy có SQL Server Express: đổi Data Source thành .\SQLEXPRESS
        private readonly string connectionString =
    @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EduManagerDB;Integrated Security=True;TrustServerCertificate=True";
        private const string SelectLopSql =
            @"SELECT l.MaLop, l.TenLop, l.MaKhoa, COUNT(sv.MaSV) AS SoSinhVien
              FROM LOP l
              LEFT JOIN SINHVIEN sv ON l.MaLop = sv.MaLop
              {0}
              GROUP BY l.MaLop, l.TenLop, l.MaKhoa
              ORDER BY l.MaLop";

        public FrmLop()
        {
            InitializeComponent();
        }

        // F1: tự động load khi mở Form
        private void FrmLop_Load(object sender, EventArgs e)
        {
            LoadKhoa();
            LoadData();
        }

        #region Truy cập dữ liệu (SqlParameter cho mọi giá trị từ người dùng - F8)

        private DataTable GetLop(string? keyword = null)
        {
            bool coTuKhoa = !string.IsNullOrWhiteSpace(keyword);
            string where = coTuKhoa ? "WHERE l.MaLop LIKE @kw OR l.TenLop LIKE @kw" : "";
            string sql = string.Format(SelectLopSql, where);

            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(sql, conn);
            if (coTuKhoa)
                cmd.Parameters.Add("@kw", SqlDbType.NVarChar, 150).Value = "%" + keyword!.Trim() + "%";

            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private DataTable GetKhoa()
        {
            const string sql = "SELECT MaKhoa, TenKhoa FROM KHOA ORDER BY MaKhoa";
            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(sql, conn);
            using var da = new SqlDataAdapter(cmd);
            var dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        private bool IsMaLopExists(string maLop)
        {
            const string sql = "SELECT COUNT(*) FROM LOP WHERE MaLop = @ma";
            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ma", SqlDbType.VarChar, 20).Value = maLop;
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }

        private int CountSinhVienByLop(string maLop)
        {
            const string sql = "SELECT COUNT(*) FROM SINHVIEN WHERE MaLop = @ma";
            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ma", SqlDbType.VarChar, 20).Value = maLop;
            conn.Open();
            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private int InsertLop(string maLop, string tenLop, string maKhoa)
        {
            const string sql = "INSERT INTO LOP(MaLop, TenLop, MaKhoa) VALUES(@ma, @ten, @khoa)";
            return ExecuteNonQuery(sql, maLop, tenLop, maKhoa);
        }

        private int UpdateLop(string maLop, string tenLop, string maKhoa)
        {
            const string sql = "UPDATE LOP SET TenLop = @ten, MaKhoa = @khoa WHERE MaLop = @ma";
            return ExecuteNonQuery(sql, maLop, tenLop, maKhoa);
        }

        private int DeleteLop(string maLop)
        {
            const string sql = "DELETE FROM LOP WHERE MaLop = @ma";
            return ExecuteNonQuery(sql, maLop, null, null);
        }

        private int ExecuteNonQuery(string sql, string maLop, string? tenLop, string? maKhoa)
        {
            using var conn = new SqlConnection(connectionString);
            using var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.Add("@ma", SqlDbType.VarChar, 20).Value = maLop;
            if (tenLop != null)
                cmd.Parameters.Add("@ten", SqlDbType.NVarChar, 100).Value = tenLop;
            if (maKhoa != null)
                cmd.Parameters.Add("@khoa", SqlDbType.VarChar, 20).Value = maKhoa;
            conn.Open();
            return cmd.ExecuteNonQuery();
        }

        #endregion

        #region Hỗ trợ giao diện

        private void LoadKhoa()
        {
            try
            {
                cboMaKhoa.DataSource = GetKhoa();
                cboMaKhoa.DisplayMember = "MaKhoa";
                cboMaKhoa.ValueMember = "MaKhoa";
                cboMaKhoa.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load danh sách khoa: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadData()
        {
            try
            {
                dgvLop.DataSource = GetLop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi load dữ liệu: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaLop.Text))
            {
                MessageBox.Show("Vui lòng nhập mã lớp.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaLop.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenLop.Text))
            {
                MessageBox.Show("Vui lòng nhập tên lớp.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLop.Focus();
                return false;
            }
            if (cboMaKhoa.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn khoa.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboMaKhoa.Focus();
                return false;
            }
            return true;
        }

        private void ClearInput()
        {
            txtMaLop.Clear();
            txtTenLop.Clear();
            txtTimKiem.Clear();
            cboMaKhoa.SelectedIndex = -1;
            txtMaLop.ReadOnly = false;   // F7: mở khóa txtMaLop
            txtMaLop.Focus();
        }

        #endregion

        #region Sự kiện

        // F2: chọn dòng -> đưa dữ liệu lên TextBox, khóa mã lớp (khóa chính không được sửa)
        private void dgvLop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            DataGridViewRow row = dgvLop.Rows[e.RowIndex];
            txtMaLop.Text = row.Cells["MaLop"].Value?.ToString() ?? "";
            txtTenLop.Text = row.Cells["TenLop"].Value?.ToString() ?? "";
            cboMaKhoa.SelectedValue = row.Cells["MaKhoa"].Value?.ToString() ?? "";
            txtMaLop.ReadOnly = true;
        }

        // F3: Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaLop.ReadOnly)
            {
                MessageBox.Show("Đang chọn một lớp có sẵn. Hãy bấm \"Làm mới\" rồi nhập mã lớp mới để thêm.",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (!ValidateInput()) return;

            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();
            string khoa = cboMaKhoa.SelectedValue!.ToString()!;

            try
            {
                if (IsMaLopExists(ma))
                {
                    MessageBox.Show("Mã lớp đã tồn tại.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaLop.Focus();
                    return;
                }

                if (InsertLop(ma, ten, khoa) > 0)
                {
                    MessageBox.Show("Thêm lớp thành công.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInput();
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm lớp: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // F4: Sửa tên lớp theo mã lớp đang chọn
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!txtMaLop.ReadOnly)
            {
                MessageBox.Show("Vui lòng chọn lớp cần sửa trong danh sách.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!ValidateInput()) return;

            string ma = txtMaLop.Text.Trim();
            string ten = txtTenLop.Text.Trim();
            string khoa = cboMaKhoa.SelectedValue!.ToString()!;

            try
            {
                if (UpdateLop(ma, ten, khoa) > 0)
                {
                    MessageBox.Show("Cập nhật lớp thành công.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInput();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lớp cần sửa.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật lớp: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // F5: Xóa - hỏi xác nhận, không cho xóa lớp đang có sinh viên
        private void btnXoa_Click(object sender, EventArgs e)
        {
            string ma = txtMaLop.Text.Trim();
            if (!txtMaLop.ReadOnly || string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Vui lòng chọn lớp cần xóa trong danh sách.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Bạn có chắc muốn xóa lớp {ma}?", "Xác nhận xóa",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                int soSV = CountSinhVienByLop(ma);
                if (soSV > 0)
                {
                    MessageBox.Show($"Không thể xóa lớp đang có {soSV} sinh viên.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (DeleteLop(ma) > 0)
                {
                    MessageBox.Show("Xóa lớp thành công.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInput();
                    LoadData();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy lớp cần xóa.", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (SqlException ex) when (ex.Number == 547) // vi phạm khóa ngoại (phòng trường hợp phát sinh sau khi kiểm tra)
            {
                MessageBox.Show("Không thể xóa lớp vì đang có sinh viên tham chiếu đến lớp này.", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa lớp: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // F6: Tìm kiếm theo mã hoặc tên lớp (LIKE + parameter)
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                dgvLop.DataSource = GetLop(txtTimKiem.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message, "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // F7: Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
            LoadData();
        }

        #endregion
    }
}

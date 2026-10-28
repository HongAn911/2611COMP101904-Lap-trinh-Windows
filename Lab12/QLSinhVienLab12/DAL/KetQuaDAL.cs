using System.Data;
using Microsoft.Data.SqlClient;

namespace QLSinhVienLab12.DAL
{
    /// <summary>
    /// Lớp truy cập dữ liệu: mọi lệnh gọi database đều đi qua stored procedure + parameter.
    /// </summary>
    public class KetQuaDAL
    {
        // Lấy danh sách lớp -> sp_Lop_GetAll
        public DataTable GetLop()
        {
            return ExecuteTable("sp_Lop_GetAll");
        }

        // Lấy danh sách môn học -> sp_MonHoc_GetAll
        public DataTable GetMonHoc()
        {
            return ExecuteTable("sp_MonHoc_GetAll");
        }

        // Lấy sinh viên của lớp kèm điểm (nếu đã có) -> sp_KetQua_GetByLopMon
        public DataTable GetKetQuaByLopMon(string maLop, string maMon)
        {
            return ExecuteTable("sp_KetQua_GetByLopMon",
                new SqlParameter("@MaLop", SqlDbType.NVarChar, 20) { Value = maLop },
                new SqlParameter("@MaMon", SqlDbType.NVarChar, 20) { Value = maMon });
        }

        /// <summary>
        /// Lưu toàn bộ các dòng trong MỘT transaction.
        /// Có bất kỳ dòng nào lỗi -> Rollback tất cả và ném lại exception.
        /// </summary>
        /// <returns>Số dòng đã lưu.</returns>
        public int SaveAll(string maMon, DataTable table)
        {
            using SqlConnection conn = new SqlConnection(Database.ConnectionString);
            conn.Open();
            using SqlTransaction trans = conn.BeginTransaction();

            try
            {
                int count = 0;
                foreach (DataRow row in table.Rows)
                {
                    if (row.RowState == DataRowState.Deleted) continue;

                    using SqlCommand cmd = new SqlCommand("sp_KetQua_Save", conn, trans);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@MaSV", SqlDbType.NVarChar, 20).Value = row["MaSV"].ToString();
                    cmd.Parameters.Add("@MaMon", SqlDbType.NVarChar, 20).Value = maMon;
                    cmd.Parameters.Add("@Diem", SqlDbType.Float).Value = Convert.ToDouble(row["Diem"]);
                    cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 255).Value =
                        row["GhiChu"] == DBNull.Value ? string.Empty : row["GhiChu"].ToString();

                    cmd.ExecuteNonQuery();
                    count++;
                }

                trans.Commit();      // chỉ commit sau khi TẤT CẢ dòng đã thành công
                return count;
            }
            catch
            {
                trans.Rollback();    // lỗi ở bất kỳ dòng nào -> huỷ toàn bộ
                throw;
            }
        }

        // Hàm dùng chung: chạy stored procedure và đổ kết quả vào DataTable
        private static DataTable ExecuteTable(string procName, params SqlParameter[] parameters)
        {
            using SqlConnection conn = new SqlConnection(Database.ConnectionString);
            using SqlCommand cmd = new SqlCommand(procName, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameters);

            using SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);     // Fill tự mở/đóng connection
            return table;
        }
    }
}

using EduManager.DAL;
using EduManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EduManager.BLL
{
    /// <summary>
    /// Ngoại lệ nghiệp vụ: chứa thông báo thân thiện để GUI hiển thị cho người dùng.
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException(string message) : base(message) { }
    }

    /// <summary>
    /// Lớp xử lý nghiệp vụ (BLL): chuẩn hóa và kiểm tra dữ liệu trước khi gọi DAL.
    /// </summary>
    public class MonHocBLL
    {
        public const int SoTinChiMin = 1;
        public const int SoTinChiMax = 6;

        private readonly MonHocDAL _dal = new MonHocDAL();

        public List<MonHoc> LayDanhSach() => _dal.GetAll();

        /// <summary>Tìm theo mã hoặc tên; từ khóa rỗng thì trả về toàn bộ danh sách.</summary>
        public List<MonHoc> TimKiem(string? tuKhoa)
        {
            string keyword = (tuKhoa ?? string.Empty).Trim();
            return keyword.Length == 0 ? _dal.GetAll() : _dal.Search(keyword);
        }

        public void Them(MonHoc monHoc)
        {
            ChuanHoa(monHoc);
            KiemTraHopLe(monHoc);

            if (_dal.Exists(monHoc.MaMonHoc))
                throw new BusinessException($"Mã môn học \"{monHoc.MaMonHoc}\" đã tồn tại. Vui lòng nhập mã khác.");

            ThucThiGhi(() => _dal.Insert(monHoc));
        }

        public void Sua(MonHoc monHoc)
        {
            ChuanHoa(monHoc);
            KiemTraHopLe(monHoc);

            bool ok = false;
            ThucThiGhi(() => ok = _dal.Update(monHoc));
            if (!ok)
                throw new BusinessException($"Không tìm thấy môn học \"{monHoc.MaMonHoc}\". Có thể dữ liệu đã bị xóa.");
        }

        public void Xoa(string? maMonHoc)
        {
            string ma = (maMonHoc ?? string.Empty).Trim().ToUpper();
            if (ma.Length == 0)
                throw new BusinessException("Vui lòng chọn môn học cần xóa.");

            bool ok = false;
            ThucThiGhi(() => ok = _dal.Delete(ma));
            if (!ok)
                throw new BusinessException($"Không tìm thấy môn học \"{ma}\". Có thể dữ liệu đã bị xóa.");
        }

        // ================== Các hàm hỗ trợ ==================

        /// <summary>Cắt khoảng trắng thừa, mã môn học viết hoa.</summary>
        private static void ChuanHoa(MonHoc monHoc)
        {
            monHoc.MaMonHoc = (monHoc.MaMonHoc ?? string.Empty).Trim().ToUpper();
            monHoc.TenMonHoc = string.Join(" ",
                (monHoc.TenMonHoc ?? string.Empty).Split(' ', StringSplitOptions.RemoveEmptyEntries));
        }

        /// <summary>Kiểm tra các ràng buộc nghiệp vụ bắt buộc của môn học.</summary>
        private static void KiemTraHopLe(MonHoc monHoc)
        {
            if (string.IsNullOrEmpty(monHoc.MaMonHoc))
                throw new BusinessException("Mã môn học không được để trống.");

            if (monHoc.MaMonHoc.Length > 10)
                throw new BusinessException("Mã môn học tối đa 10 ký tự.");

            if (monHoc.MaMonHoc.Contains(' '))
                throw new BusinessException("Mã môn học không được chứa khoảng trắng.");

            if (string.IsNullOrEmpty(monHoc.TenMonHoc))
                throw new BusinessException("Tên môn học không được để trống.");

            if (monHoc.TenMonHoc.Length > 100)
                throw new BusinessException("Tên môn học tối đa 100 ký tự.");

            if (monHoc.SoTinChi < SoTinChiMin || monHoc.SoTinChi > SoTinChiMax)
                throw new BusinessException($"Số tín chỉ phải nằm trong khoảng từ {SoTinChiMin} đến {SoTinChiMax}.");
        }

        /// <summary>Gọi DAL và đổi lỗi database thành thông báo dễ hiểu.</summary>
        private static void ThucThiGhi(Action action)
        {
            try
            {
                action();
            }
            catch (DbUpdateException ex)
            {
                string chiTiet = ex.InnerException?.Message ?? ex.Message;

                if (chiTiet.Contains("PRIMARY KEY") || chiTiet.Contains("duplicate key"))
                    throw new BusinessException("Mã môn học đã tồn tại trong cơ sở dữ liệu.");

                if (chiTiet.Contains("REFERENCE") || chiTiet.Contains("FOREIGN KEY"))
                    throw new BusinessException("Không thể xóa vì môn học đang được sử dụng ở dữ liệu khác (ví dụ: bảng điểm).");

                if (chiTiet.Contains("CHECK"))
                    throw new BusinessException($"Số tín chỉ phải nằm trong khoảng từ {SoTinChiMin} đến {SoTinChiMax}.");

                throw new BusinessException("Không thể lưu dữ liệu xuống cơ sở dữ liệu.\nChi tiết: " + chiTiet);
            }
        }
    }
}

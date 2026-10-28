using EduManager.Data;
using EduManager.Models;
using Microsoft.EntityFrameworkCore;

namespace EduManager.DAL
{
    /// <summary>
    /// Lớp truy cập dữ liệu (DAL): chỉ làm việc với database thông qua EF Core,
    /// không kiểm tra nghiệp vụ.
    /// </summary>
    public class MonHocDAL
    {
        /// <summary>Lấy toàn bộ môn học, sắp xếp theo mã.</summary>
        public List<MonHoc> GetAll()
        {
            using var db = new EduManagerContext();
            return db.MonHocs
                     .AsNoTracking()
                     .OrderBy(m => m.MaMonHoc)
                     .ToList();
        }

        /// <summary>Tìm môn học có mã hoặc tên chứa từ khóa.</summary>
        public List<MonHoc> Search(string keyword)
        {
            using var db = new EduManagerContext();
            return db.MonHocs
                     .AsNoTracking()
                     .Where(m => m.MaMonHoc.Contains(keyword) || m.TenMonHoc.Contains(keyword))
                     .OrderBy(m => m.MaMonHoc)
                     .ToList();
        }

        /// <summary>Lấy một môn học theo mã, trả về null nếu không có.</summary>
        public MonHoc? GetById(string maMonHoc)
        {
            using var db = new EduManagerContext();
            return db.MonHocs.AsNoTracking().FirstOrDefault(m => m.MaMonHoc == maMonHoc);
        }

        /// <summary>Kiểm tra mã môn học đã tồn tại hay chưa.</summary>
        public bool Exists(string maMonHoc)
        {
            using var db = new EduManagerContext();
            return db.MonHocs.Any(m => m.MaMonHoc == maMonHoc);
        }

        /// <summary>Thêm môn học mới.</summary>
        public void Insert(MonHoc monHoc)
        {
            using var db = new EduManagerContext();
            db.MonHocs.Add(monHoc);
            db.SaveChanges();
        }

        /// <summary>Cập nhật môn học. Trả về false nếu không tìm thấy mã.</summary>
        public bool Update(MonHoc monHoc)
        {
            using var db = new EduManagerContext();
            var entity = db.MonHocs.Find(monHoc.MaMonHoc);
            if (entity == null) return false;

            entity.TenMonHoc = monHoc.TenMonHoc;
            entity.SoTinChi = monHoc.SoTinChi;
            entity.TrangThai = monHoc.TrangThai;
            db.SaveChanges();
            return true;
        }

        /// <summary>Xóa môn học theo mã. Trả về false nếu không tìm thấy mã.</summary>
        public bool Delete(string maMonHoc)
        {
            using var db = new EduManagerContext();
            var entity = db.MonHocs.Find(maMonHoc);
            if (entity == null) return false;

            db.MonHocs.Remove(entity);
            db.SaveChanges();
            return true;
        }
    }
}

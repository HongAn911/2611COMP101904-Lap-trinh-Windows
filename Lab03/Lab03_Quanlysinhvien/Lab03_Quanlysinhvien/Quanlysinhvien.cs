using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab03_QuanLySinhVienOOP
{
    // Class chịu trách nhiệm quản lý List<SinhVien>, Program không xử lý danh sách trực tiếp
    public class QuanLySinhVien
    {
        private readonly List<SinhVien> _danhSach = new List<SinhVien>();

        // Thêm sinh viên, kiểm tra mã không được trùng
        public bool Them(SinhVien sv)
        {
            if (_danhSach.Any(s => s.MaSinhVien.Equals(sv.MaSinhVien, StringComparison.OrdinalIgnoreCase)))
            {
                return false; // mã đã tồn tại
            }
            _danhSach.Add(sv);
            return true;
        }

        // Sửa điểm trung bình theo mã sinh viên
        public bool Sua(string maSinhVien, double diemMoi)
        {
            var sv = TimTheoMa(maSinhVien);
            if (sv == null) return false;

            sv.DiemTrungBinh = diemMoi; // property tự kiểm tra 0-10
            return true;
        }

        // Xóa sinh viên theo mã
        public bool Xoa(string maSinhVien)
        {
            var sv = TimTheoMa(maSinhVien);
            if (sv == null) return false;

            _danhSach.Remove(sv);
            return true;
        }

        // Tìm theo mã (dùng LINQ)
        public SinhVien TimTheoMa(string maSinhVien)
        {
            return _danhSach.FirstOrDefault(s =>
                s.MaSinhVien.Equals(maSinhVien, StringComparison.OrdinalIgnoreCase));
        }

        // Tìm theo tên, cho phép tìm gần đúng theo từ khóa (dùng LINQ)
        public List<SinhVien> TimTheoTen(string tuKhoa)
        {
            return _danhSach
                .Where(s => s.HoTen.Contains(tuKhoa, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // Sắp xếp theo điểm giảm dần (dùng LINQ)
        public List<SinhVien> SapXepTheoDiem()
        {
            return _danhSach
                .OrderByDescending(s => s.DiemTrungBinh)
                .ToList();
        }

        // Lọc sinh viên đạt (điểm >= 5) (dùng LINQ)
        public List<SinhVien> LocSinhVienDat()
        {
            return _danhSach
                .Where(s => s.DiemTrungBinh >= 5)
                .ToList();
        }

        // Lấy toàn bộ danh sách
        public List<SinhVien> LayDanhSach()
        {
            return _danhSach;
        }
    }
}
using System;

namespace QuanLyNhanVien
{
    // Lớp cha: NhanVien
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }

        private double _luongCoBan;
        public double LuongCoBan
        {
            get => _luongCoBan;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Lương cơ bản phải lớn hơn 0.");
                _luongCoBan = value;
            }
        }

        public NhanVien(string maNV, string hoTen, double luongCoBan)
        {
            MaNV = maNV;
            HoTen = hoTen;
            LuongCoBan = luongCoBan; // đi qua property để kiểm tra
        }

        // Đa hình: các lớp con override để tính lương theo cách riêng
        public virtual double TinhLuong()
        {
            return LuongCoBan;
        }

        // Đa hình: các lớp con override để hiển thị thông tin riêng
        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"Mã NV: {MaNV,-8} | Họ tên: {HoTen,-20} | Loại: Nhân viên | Lương: {TinhLuong():N0} VNĐ");
        }
    }
}
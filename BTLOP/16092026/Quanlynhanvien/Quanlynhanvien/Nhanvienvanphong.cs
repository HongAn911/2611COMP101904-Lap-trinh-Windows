using System;

namespace QuanLyNhanVien
{
    // Kế thừa từ NhanVien
    public class NhanVienVanPhong : NhanVien
    {
        private const double DON_GIA_NGAY = 200000;

        private int _soNgayLamViec;
        public int SoNgayLamViec
        {
            get => _soNgayLamViec;
            set
            {
                if (value < 0 || value > 31)
                    throw new ArgumentException("Số ngày làm việc phải trong khoảng 0 - 31.");
                _soNgayLamViec = value;
            }
        }

        public NhanVienVanPhong(string maNV, string hoTen, double luongCoBan, int soNgayLamViec)
            : base(maNV, hoTen, luongCoBan)
        {
            SoNgayLamViec = soNgayLamViec; // đi qua property để kiểm tra
        }

        public override double TinhLuong()
        {
            return LuongCoBan + SoNgayLamViec * DON_GIA_NGAY;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"Mã NV: {MaNV,-8} | Họ tên: {HoTen,-20} | Loại: Văn phòng | Số ngày làm: {SoNgayLamViec,-3} | Lương: {TinhLuong():N0} VNĐ");
        }
    }
}
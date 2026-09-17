using System;

namespace QuanLyNhanVien
{
    // Kế thừa từ NhanVien
    public class NhanVienKinhDoanh : NhanVien
    {
        private const double TI_LE_HOA_HONG = 0.05;

        private double _doanhSo;
        public double DoanhSo
        {
            get => _doanhSo;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Doanh số phải lớn hơn hoặc bằng 0.");
                _doanhSo = value;
            }
        }

        public NhanVienKinhDoanh(string maNV, string hoTen, double luongCoBan, double doanhSo)
            : base(maNV, hoTen, luongCoBan)
        {
            DoanhSo = doanhSo; // đi qua property để kiểm tra
        }

        public override double TinhLuong()
        {
            return LuongCoBan + TI_LE_HOA_HONG * DoanhSo;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"Mã NV: {MaNV,-8} | Họ tên: {HoTen,-20} | Loại: Kinh doanh | Doanh số: {DoanhSo,-10:N0} | Lương: {TinhLuong():N0} VNĐ");
        }
    }
}
using System;

namespace QuanLyNhanVien
{
    // Bonus: kế thừa từ NhanVien
    // Lương của nhân viên thời vụ không phụ thuộc LuongCoBan,
    // nhưng lớp cha yêu cầu LuongCoBan > 0 nên constructor truyền
    // sẵn một giá trị hợp lệ (1) cho lớp cha, không cho người dùng nhập.
    public class NhanVienThoiVu : NhanVien
    {
        private double _soGioLam;
        public double SoGioLam
        {
            get => _soGioLam;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Số giờ làm phải lớn hơn hoặc bằng 0.");
                _soGioLam = value;
            }
        }

        private double _luongTheoGio;
        public double LuongTheoGio
        {
            get => _luongTheoGio;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Lương theo giờ phải lớn hơn hoặc bằng 0.");
                _luongTheoGio = value;
            }
        }

        public NhanVienThoiVu(string maNV, string hoTen, double soGioLam, double luongTheoGio)
            : base(maNV, hoTen, 1) // truyền giá trị hợp lệ (>0) cho lớp cha, không dùng để tính lương
        {
            SoGioLam = soGioLam;
            LuongTheoGio = luongTheoGio;
        }

        public override double TinhLuong()
        {
            return SoGioLam * LuongTheoGio;
        }

        public override void HienThiThongTin()
        {
            Console.WriteLine($"Mã NV: {MaNV,-8} | Họ tên: {HoTen,-20} | Loại: Thời vụ  | Số giờ: {SoGioLam,-5} | Lương/giờ: {LuongTheoGio,-10:N0} | Lương: {TinhLuong():N0} VNĐ");
        }
    }
}
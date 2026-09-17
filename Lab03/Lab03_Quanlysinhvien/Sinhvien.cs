using System;

namespace Lab03_QuanLySinhVienOOP
{
    // Kế thừa từ Nguoi
    public class SinhVien : Nguoi
    {
        public string MaSinhVien { get; set; }
        public string MaLop { get; set; }

        private double _diemTrungBinh;

        // Property có kiểm tra dữ liệu: chỉ nhận giá trị từ 0 đến 10
        public double DiemTrungBinh
        {
            get => _diemTrungBinh;
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(DiemTrungBinh), "Điểm trung bình phải nằm trong khoảng 0 đến 10.");
                }
                _diemTrungBinh = value;
            }
        }

        public SinhVien(string maSinhVien, string hoTen, DateTime ngaySinh, string maLop, double diemTrungBinh)
            : base(hoTen, ngaySinh)
        {
            MaSinhVien = maSinhVien;
            MaLop = maLop;
            DiemTrungBinh = diemTrungBinh; // đi qua property để kiểm tra
        }

        // Xếp loại dựa trên điểm trung bình
        public string XepLoai()
        {
            if (DiemTrungBinh >= 8.0) return "Giỏi";
            if (DiemTrungBinh >= 6.5) return "Khá";
            if (DiemTrungBinh >= 5.0) return "Trung bình";
            return "Yếu";
        }

        // Override để in thêm thông tin riêng của sinh viên
        public override string LayThongTin()
        {
            return $"{MaSinhVien,-8} {HoTen,-25} {MaLop,-10} {DiemTrungBinh,-6:0.0} {XepLoai()}";
        }
    }
}
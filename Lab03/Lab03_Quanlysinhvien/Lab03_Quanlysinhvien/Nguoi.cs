using System;

namespace Lab03_QuanLySinhVienOOP
{
    // Class cha: đại diện cho một con người nói chung
    public class Nguoi
    {
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }

        public Nguoi(string hoTen, DateTime ngaySinh)
        {
            HoTen = hoTen;
            NgaySinh = ngaySinh;
        }

        // Có thể override ở lớp con để bổ sung thông tin riêng
        public virtual string LayThongTin()
        {
            return $"Họ tên: {HoTen} - Ngày sinh: {NgaySinh:dd/MM/yyyy}";
        }
    }
}
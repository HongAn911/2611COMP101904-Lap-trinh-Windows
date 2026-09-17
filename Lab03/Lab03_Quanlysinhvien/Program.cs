using System;
using System.Globalization;

namespace Lab03_QuanLySinhVienOOP
{
    public class Program
    {
        private static readonly QuanLySinhVien _quanLy = new QuanLySinhVien();

        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            bool tiepTuc = true;

            while (tiepTuc)
            {
                HienThiMenu();
                string luaChon = Console.ReadLine()?.Trim();

                switch (luaChon)
                {
                    case "1":
                        ThemSinhVien();
                        break;
                    case "2":
                        XuatDanhSach(_quanLy.LayDanhSach());
                        break;
                    case "3":
                        TimTheoMa();
                        break;
                    case "4":
                        TimTheoTen();
                        break;
                    case "5":
                        SuaDiem();
                        break;
                    case "6":
                        XoaSinhVien();
                        break;
                    case "7":
                        Console.WriteLine("\n--- Danh sách sắp xếp theo điểm giảm dần ---");
                        XuatDanhSach(_quanLy.SapXepTheoDiem());
                        break;
                    case "8":
                        Console.WriteLine("\n--- Danh sách sinh viên đạt (điểm >= 5) ---");
                        XuatDanhSach(_quanLy.LocSinhVienDat());
                        break;
                    case "0":
                        tiepTuc = false;
                        Console.WriteLine("Tạm biệt!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng chọn lại.");
                        break;
                }

                if (tiepTuc)
                {
                    Console.WriteLine("\nNhấn Enter để tiếp tục...");
                    Console.ReadLine();
                }
            }
        }

        private static void HienThiMenu()
        {
            Console.Clear();
            Console.WriteLine("===== QUAN LY SINH VIEN =====");
            Console.WriteLine("1. Them sinh vien");
            Console.WriteLine("2. Xuat danh sach");
            Console.WriteLine("3. Tim sinh vien theo ma");
            Console.WriteLine("4. Tim sinh vien theo ten");
            Console.WriteLine("5. Sua diem trung binh");
            Console.WriteLine("6. Xoa sinh vien");
            Console.WriteLine("7. Sap xep theo diem giam dan");
            Console.WriteLine("8. Loc sinh vien dat");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon chuc nang: ");
        }

        // ----- Các hàm nhập dữ liệu / xử lý luồng chương trình -----

        private static void ThemSinhVien()
        {
            Console.WriteLine("\n--- Thêm sinh viên ---");

            Console.Write("Mã sinh viên: ");
            string ma = Console.ReadLine()?.Trim();

            Console.Write("Họ tên: ");
            string hoTen = Console.ReadLine()?.Trim();

            DateTime ngaySinh = NhapNgaySinh();

            Console.Write("Mã lớp: ");
            string maLop = Console.ReadLine()?.Trim();

            double diem = NhapDiemHopLe();

            try
            {
                var sv = new SinhVien(ma, hoTen, ngaySinh, maLop, diem);
                bool thanhCong = _quanLy.Them(sv);

                if (thanhCong)
                    Console.WriteLine($"Thêm thành công. Xếp loại: {sv.XepLoai()}");
                else
                    Console.WriteLine($"Lỗi: Mã sinh viên '{ma}' đã tồn tại.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Lỗi dữ liệu: {ex.Message}");
            }
        }

        private static void XuatDanhSach(System.Collections.Generic.List<SinhVien> danhSach)
        {
            Console.WriteLine("\n--- Danh sách sinh viên ---");
            if (danhSach.Count == 0)
            {
                Console.WriteLine("(Danh sách rỗng)");
                return;
            }

            Console.WriteLine($"{"Mã SV",-8} {"Họ tên",-25} {"Lớp",-10} {"Điểm",-6} Xếp loại");
            Console.WriteLine(new string('-', 60));
            foreach (var sv in danhSach)
            {
                Console.WriteLine(sv.LayThongTin());
            }
        }

        private static void TimTheoMa()
        {
            Console.Write("\nNhập mã sinh viên cần tìm: ");
            string ma = Console.ReadLine()?.Trim();

            var sv = _quanLy.TimTheoMa(ma);
            if (sv == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên với mã này.");
            }
            else
            {
                Console.WriteLine("\nTìm thấy:");
                Console.WriteLine(sv.LayThongTin());
            }
        }

        private static void TimTheoTen()
        {
            Console.Write("\nNhập từ khóa họ tên cần tìm: ");
            string tuKhoa = Console.ReadLine()?.Trim();

            var ketQua = _quanLy.TimTheoTen(tuKhoa);
            XuatDanhSach(ketQua);
        }

        private static void SuaDiem()
        {
            Console.Write("\nNhập mã sinh viên cần sửa điểm: ");
            string ma = Console.ReadLine()?.Trim();

            var sv = _quanLy.TimTheoMa(ma);
            if (sv == null)
            {
                Console.WriteLine("Không tìm thấy sinh viên với mã này.");
                return;
            }

            double diemMoi = NhapDiemHopLe();

            try
            {
                _quanLy.Sua(ma, diemMoi);
                Console.WriteLine("Cập nhật điểm thành công.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Lỗi dữ liệu: {ex.Message}");
            }
        }

        private static void XoaSinhVien()
        {
            Console.Write("\nNhập mã sinh viên cần xóa: ");
            string ma = Console.ReadLine()?.Trim();

            bool thanhCong = _quanLy.Xoa(ma);
            Console.WriteLine(thanhCong
                ? "Xóa thành công."
                : "Không tìm thấy sinh viên với mã này.");
        }

        // ----- Các hàm hỗ trợ nhập liệu an toàn (không để chương trình crash) -----

        private static double NhapDiemHopLe()
        {
            double diem;
            while (true)
            {
                Console.Write("Điểm trung bình (0-10): ");
                string input = Console.ReadLine()?.Trim();

                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out diem)
                    && diem >= 0 && diem <= 10)
                {
                    return diem;
                }

                Console.WriteLine("Điểm không hợp lệ, vui lòng nhập lại (giá trị số từ 0 đến 10).");
            }
        }

        private static DateTime NhapNgaySinh()
        {
            DateTime ngaySinh;
            while (true)
            {
                Console.Write("Ngày sinh (dd/MM/yyyy): ");
                string input = Console.ReadLine()?.Trim();

                if (DateTime.TryParseExact(input, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out ngaySinh))
                {
                    return ngaySinh;
                }

                Console.WriteLine("Ngày sinh không hợp lệ, vui lòng nhập lại theo định dạng dd/MM/yyyy.");
            }
        }
    }
}
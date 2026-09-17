using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyNhanVien
{
    class Program
    {
        static List<NhanVien> danhSach = new List<NhanVien>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            KhoiTaoDuLieu(); // Ít nhất 5 nhân viên thuộc NhanVienVanPhong và NhanVienKinhDoanh

            int luaChon;
            do
            {
                HienThiMenu();
                luaChon = DocSoNguyen("Chọn chức năng: ");

                switch (luaChon)
                {
                    case 1:
                        XuatDanhSach();
                        break;
                    case 2:
                        TimTheoMa();
                        break;
                    case 3:
                        TimLuongCaoNhat();
                        break;
                    case 4:
                        TinhTongLuong();
                        break;
                    case 0:
                        Console.WriteLine("Tạm biệt!");
                        break;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
                Console.WriteLine();

            } while (luaChon != 0);
        }

        static void HienThiMenu()
        {
            Console.WriteLine("========== MENU ==========");
            Console.WriteLine("1. Xuất danh sách nhân viên");
            Console.WriteLine("2. Tìm nhân viên theo mã");
            Console.WriteLine("3. Tìm nhân viên có lương cao nhất");
            Console.WriteLine("4. Tính tổng lương công ty phải trả");
            Console.WriteLine("0. Thoát");
            Console.WriteLine("===========================");
        }

        // 1. Xuất danh sách — dùng đa hình qua HienThiThongTin(),
        //    không cần biết từng phần tử thuộc lớp con nào.
        static void XuatDanhSach()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách nhân viên rỗng.");
                return;
            }

            Console.WriteLine("----- DANH SÁCH NHÂN VIÊN -----");
            foreach (NhanVien nv in danhSach)
            {
                nv.HienThiThongTin();
            }
        }

        // 2. Tìm theo mã (LINQ)
        static void TimTheoMa()
        {
            Console.Write("Nhập mã nhân viên cần tìm: ");
            string ma = Console.ReadLine();

            NhanVien tim = danhSach.FirstOrDefault(nv => nv.MaNV.Equals(ma, StringComparison.OrdinalIgnoreCase));

            if (tim != null)
            {
                Console.WriteLine("Tìm thấy:");
                tim.HienThiThongTin();
            }
            else
            {
                Console.WriteLine($"Không tìm thấy nhân viên có mã '{ma}'.");
            }
        }

        // 3. Tìm lương cao nhất — chỉ gọi TinhLuong() qua đa hình,
        //    không if/switch theo loại nhân viên. Không cần sửa khi
        //    thêm loại nhân viên mới (ví dụ NhanVienThoiVu).
        static void TimLuongCaoNhat()
        {
            if (danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách nhân viên rỗng.");
                return;
            }

            NhanVien nvLuongCaoNhat = danhSach[0];
            foreach (NhanVien nv in danhSach)
            {
                if (nv.TinhLuong() > nvLuongCaoNhat.TinhLuong())
                {
                    nvLuongCaoNhat = nv;
                }
            }

            Console.WriteLine("Nhân viên có lương cao nhất:");
            nvLuongCaoNhat.HienThiThongTin();
        }

        // 4. Tính tổng lương — chỉ gọi TinhLuong() qua đa hình.
        //    Không cần sửa khi thêm loại nhân viên mới.
        static void TinhTongLuong()
        {
            double tong = 0;
            foreach (NhanVien nv in danhSach)
            {
                tong += nv.TinhLuong();
            }
            Console.WriteLine($"Tổng lương công ty phải trả: {tong:N0} VNĐ");
        }

        // Khởi tạo ít nhất 5 nhân viên thuộc 2 loại chính, cùng
        // 1 nhân viên thời vụ (bonus) để minh họa mở rộng không sửa
        // thuật toán ở mục 3 và 4.
        static void KhoiTaoDuLieu()
        {
            danhSach.Add(new NhanVienVanPhong("NV001", "Nguyễn Văn An", 5000000, 22));
            danhSach.Add(new NhanVienVanPhong("NV002", "Trần Thị Bích", 5500000, 20));
            danhSach.Add(new NhanVienKinhDoanh("NV003", "Lê Văn Chương", 4000000, 50000000));
            danhSach.Add(new NhanVienKinhDoanh("NV004", "Phạm Thị Dung", 4500000, 30000000));
            danhSach.Add(new NhanVienVanPhong("NV005", "Hoàng Văn Tuấn", 6000000, 26));

            // Bonus: thêm loại nhân viên mới mà không phải sửa
            // TimLuongCaoNhat() hay TinhTongLuong()
            danhSach.Add(new NhanVienThoiVu("NV006", "Đỗ Thị Ngọc", 80, 50000));
        }

        // Hàm hỗ trợ nhập liệu an toàn: không dừng bất thường khi nhập sai kiểu
        static int DocSoNguyen(string thongBao)
        {
            int ketQua;
            Console.Write(thongBao);
            while (!int.TryParse(Console.ReadLine(), out ketQua))
            {
                Console.Write("Vui lòng nhập số nguyên hợp lệ: ");
            }
            return ketQua;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyNhanVien
{
    // LỚP CHA: NhanVien
    public class NhanVien
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public double LuongCoBan { get; set; }

        public NhanVien(string maNV, string hoTen, double luongCoBan)
        {
            MaNV = maNV;
            HoTen = hoTen;
            if (luongCoBan <= 0)
                throw new ArgumentException("Lương cơ bản phải lớn hơn 0.");
            LuongCoBan = luongCoBan;
        }

        // Phương thức ảo để các lớp con override (đa hình)
        public virtual double TinhLuong()
        {
            return LuongCoBan;
        }

        public virtual void HienThiThongTin()
        {
            Console.WriteLine($"Mã NV: {MaNV,-8} | Họ tên: {HoTen,-20} | Loại: Nhân viên | Lương: {TinhLuong():N0} VNĐ");
        }
    }

    // LỚP KẾ THỪA: NhanVienVanPhong
    public class NhanVienVanPhong : NhanVien
    {
        public int SoNgayLamViec { get; set; }
        private const double DON_GIA_NGAY = 200000;

        public NhanVienVanPhong(string maNV, string hoTen, double luongCoBan, int soNgayLamViec)
            : base(maNV, hoTen, luongCoBan)
        {
            if (soNgayLamViec < 0 || soNgayLamViec > 31)
                throw new ArgumentException("Số ngày làm việc phải trong khoảng 0 - 31.");
            SoNgayLamViec = soNgayLamViec;
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

    // LỚP KẾ THỪA: NhanVienKinhDoanh
    public class NhanVienKinhDoanh : NhanVien
    {
        public double DoanhSo { get; set; }
        private const double TI_LE_HOA_HONG = 0.05;

        public NhanVienKinhDoanh(string maNV, string hoTen, double luongCoBan, double doanhSo)
            : base(maNV, hoTen, luongCoBan)
        {
            if (doanhSo < 0)
                throw new ArgumentException("Doanh số phải >= 0.");
            DoanhSo = doanhSo;
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

    // LỚP BONUS: NhanVienThoiVu
    public class NhanVienThoiVu : NhanVien
    {
        public double SoGioLam { get; set; }
        public double LuongTheoGio { get; set; }

        // Lưu ý: lớp này không dùng LuongCoBan để tính lương,
        // nhưng vẫn phải truyền 1 giá trị > 0 cho lớp cha vì
        // constructor cha yêu cầu LuongCoBan > 0.
        public NhanVienThoiVu(string maNV, string hoTen, double luongCoBan, double soGioLam, double luongTheoGio)
            : base(maNV, hoTen, luongCoBan)
        {
            if (soGioLam < 0)
                throw new ArgumentException("Số giờ làm phải >= 0.");
            if (luongTheoGio < 0)
                throw new ArgumentException("Lương theo giờ phải >= 0.");
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

    // CHƯƠNG TRÌNH CHÍNH
    class Program
    {
        static List<NhanVien> danhSach = new List<NhanVien>();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            NhapDuLieuMauBanDau(); // Tạo sẵn ít nhất 5 nhân viên để thuận tiện chạy thử

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

        // 1. Xuất danh sách (đa hình qua HienThiThongTin())
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
                nv.HienThiThongTin(); // Gọi đa hình - không cần biết là loại nào
            }
        }

        // 2. Tìm theo mã
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

        // 3. Tìm lương cao nhất (chỉ dùng TinhLuong(), không if/switch loại NV)
        //    Thuật toán này không cần sửa khi thêm loại nhân viên mới.
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

        // 4. Tính tổng lương (chỉ dùng TinhLuong())
        //    Thuật toán này không cần sửa khi thêm loại nhân viên mới.
        static void TinhTongLuong()
        {
            double tong = 0;
            foreach (NhanVien nv in danhSach)
            {
                tong += nv.TinhLuong();
            }
            Console.WriteLine($"Tổng lương công ty phải trả: {tong:N0} VNĐ");
        }

        // Dữ liệu mẫu ban đầu (>= 5 nhân viên thuộc 2 loại chính)
        static void NhapDuLieuMauBanDau()
        {
            danhSach.Add(new NhanVienVanPhong("NV001", "Nguyễn Văn An", 5000000, 22));
            danhSach.Add(new NhanVienVanPhong("NV002", "Trần Thị Bích", 5500000, 20));
            danhSach.Add(new NhanVienKinhDoanh("NV003", "Lê Văn Chương", 4000000, 50000000));
            danhSach.Add(new NhanVienKinhDoanh("NV004", "Phạm Thị Dung", 4500000, 30000000));
            danhSach.Add(new NhanVienVanPhong("NV005", "Hoàng Văn Tuấn", 6000000, 26));
            danhSach.Add(new NhanVienThoiVu("NV006", "Đỗ Thị Ngọc", 1000000, 80, 50000));
        }

        // Hàm hỗ trợ nhập liệu an toàn
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
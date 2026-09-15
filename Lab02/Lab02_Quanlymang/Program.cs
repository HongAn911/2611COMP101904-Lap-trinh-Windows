using System;

namespace Lab02_QuanLyMangSoNguyen
{
    class Program
    {
        // Mảng số nguyên dùng chung cho chương trình, và cờ đánh dấu đã nhập mảng hay chưa
        static int[] mang = null;
        static bool daNhapMang = false;

        static void Main(string[] args)
        {
            int luaChon;

            do
            {
                HienThiMenu();
                luaChon = NhapLuaChonMenu();

                switch (luaChon)
                {
                    case 1:
                        mang = NhapMang();
                        daNhapMang = true;
                        Console.WriteLine("Nhap mang thanh cong!");
                        break;

                    case 2:
                        if (KiemTraDaNhapMang())
                        {
                            Console.Write("Mang vua nhap: ");
                            XuatMang(mang);
                        }
                        break;

                    case 3:
                        if (KiemTraDaNhapMang())
                        {
                            int tong = TinhTong(mang);
                            Console.WriteLine("Tong cac phan tu = " + tong);
                        }
                        break;

                    case 4:
                        if (KiemTraDaNhapMang())
                        {
                            int max = TimMax(mang);
                            int min = TimMin(mang);
                            Console.WriteLine("Gia tri lon nhat = " + max);
                            Console.WriteLine("Gia tri nho nhat = " + min);
                        }
                        break;

                    case 5:
                        if (KiemTraDaNhapMang())
                        {
                            int soChan = DemChan(mang);
                            int soLe = DemLe(mang);
                            Console.WriteLine("So luong phan tu chan = " + soChan);
                            Console.WriteLine("So luong phan tu le = " + soLe);
                        }
                        break;

                    case 6:
                        if (KiemTraDaNhapMang())
                        {
                            SapXepTangDan(mang);
                            Console.Write("Mang sau khi sap xep tang dan: ");
                            XuatMang(mang);
                        }
                        break;

                    case 7:
                        if (KiemTraDaNhapMang())
                        {
                            int x = NhapSoNguyen("Nhap gia tri x can tim: ");
                            int viTri = TimKiem(mang, x);
                            if (viTri != -1)
                                Console.WriteLine("Tim thay x = " + x + " tai vi tri " + viTri);
                            else
                                Console.WriteLine("Khong tim thay x = " + x + " trong mang.");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Ket thuc chuong trinh. Tam biet!");
                        break;

                    default:
                        Console.WriteLine("Lua chon khong hop le. Vui long chon lai.");
                        break;
                }

                if (luaChon != 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Nhan phim bat ky de tiep tuc...");
                    Console.ReadKey();
                    Console.Clear();
                }

            } while (luaChon != 0);
        }

        // ===================== CAC PHUONG THUC HO TRO =====================

        // Hien thi menu chuc nang
        static void HienThiMenu()
        {
            Console.WriteLine("===== MENU =====");
            Console.WriteLine("1. Nhap mang");
            Console.WriteLine("2. Xuat mang");
            Console.WriteLine("3. Tinh tong");
            Console.WriteLine("4. Tim max/min");
            Console.WriteLine("5. Dem chan/le");
            Console.WriteLine("6. Sap xep tang dan");
            Console.WriteLine("7. Tim kiem");
            Console.WriteLine("0. Thoat");
            Console.Write("Chon chuc nang: ");
        }

        // Nhap lua chon menu, dam bao khong bi crash neu nhap sai kieu du lieu
        static int NhapLuaChonMenu()
        {
            string input = Console.ReadLine();
            int luaChon;
            bool hopLe = int.TryParse(input, out luaChon);

            if (!hopLe)
            {
                // Tra ve mot gia tri khong nam trong danh sach chuc nang de vao nhanh "default"
                return -999;
            }
            return luaChon;
        }

        // Kiem tra xem mang da duoc nhap hay chua truoc khi cho thuc hien cac chuc nang xu ly
        static bool KiemTraDaNhapMang()
        {
            if (!daNhapMang)
            {
                Console.WriteLine("Ban chua nhap mang! Vui long chon chuc nang 1 de nhap mang truoc.");
                return false;
            }
            return true;
        }

        // Nhap mot so nguyen bat ky, kiem tra du lieu nhap hop le
        static int NhapSoNguyen(string message)
        {
            int soNguyen;
            bool hopLe;

            do
            {
                Console.Write(message);
                string input = Console.ReadLine();
                hopLe = int.TryParse(input, out soNguyen);

                if (!hopLe)
                {
                    Console.WriteLine("Du lieu nhap khong hop le. Vui long nhap lai mot so nguyen.");
                }
            } while (!hopLe);

            return soNguyen;
        }

        // Nhap mot so nguyen duong (dung cho so luong phan tu cua mang)
        static int NhapSoNguyenDuong(string message)
        {
            int soNguyen;

            do
            {
                soNguyen = NhapSoNguyen(message);

                if (soNguyen <= 0)
                {
                    Console.WriteLine("So luong phan tu phai la so nguyen duong. Vui long nhap lai.");
                }
            } while (soNguyen <= 0);

            return soNguyen;
        }

        // Nhap mang: nhap so luong phan tu n, sau do nhap tung phan tu
        static int[] NhapMang()
        {
            int n = NhapSoNguyenDuong("Nhap so luong phan tu n (n > 0): ");
            int[] a = new int[n];

            for (int i = 0; i < n; i++)
            {
                a[i] = NhapSoNguyen("Nhap phan tu thu " + (i + 1) + ": ");
            }

            return a;
        }

        // Xuat toan bo phan tu cua mang ra man hinh
        static void XuatMang(int[] a)
        {
            Console.Write("[ ");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i] + " ");
            }
            Console.WriteLine("]");
        }

        // Tinh tong cac phan tu trong mang
        static int TinhTong(int[] a)
        {
            int tong = 0;
            for (int i = 0; i < a.Length; i++)
            {
                tong += a[i];
            }
            return tong;
        }

        // Tim gia tri lon nhat trong mang
        static int TimMax(int[] a)
        {
            int max = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] > max)
                    max = a[i];
            }
            return max;
        }

        // Tim gia tri nho nhat trong mang
        static int TimMin(int[] a)
        {
            int min = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] < min)
                    min = a[i];
            }
            return min;
        }

        // Dem so luong phan tu chan trong mang
        static int DemChan(int[] a)
        {
            int dem = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 == 0)
                    dem++;
            }
            return dem;
        }

        // Dem so luong phan tu le trong mang
        static int DemLe(int[] a)
        {
            int dem = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] % 2 != 0)
                    dem++;
            }
            return dem;
        }

        // Sap xep mang theo thu tu tang dan (thuat toan Bubble Sort don gian, de hieu)
        static void SapXepTangDan(int[] a)
        {
            for (int i = 0; i < a.Length - 1; i++)
            {
                for (int j = 0; j < a.Length - 1 - i; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        int tam = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = tam;
                    }
                }
            }
        }

        // Tim kiem gia tri x trong mang, tra ve vi tri xuat hien dau tien (tinh tu 0), neu khong co tra ve -1
        static int TimKiem(int[] a, int x)
        {
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == x)
                    return i;
            }
            return -1;
        }
    }
}
using System.Text;

namespace ProductManager;

public class Program
{
    private static readonly ProductService Service = new();

    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Đăng ký lắng nghe event
        Service.ProductAdded += p => Console.WriteLine($"[EVENT] Da them san pham: {p.MaSP} - {p.TenSP}");
        Service.ProductRemoved += p => Console.WriteLine($"[EVENT] Da xoa san pham: {p.MaSP} - {p.TenSP}");

        bool isRunning = true;
        while (isRunning)
        {
            ShowMenu();
            string? choice = Console.ReadLine()?.Trim();
            Console.WriteLine();

            try
            {
                switch (choice)
                {
                    case "1": AddProduct(); break;
                    case "2": ShowAllProducts(); break;
                    case "3": FindById(); break;
                    case "4": FindByName(); break;
                    case "5": FilterByPriceRange(); break;
                    case "6": RemoveProduct(); break;
                    case "7": ShowTotalValue(); break;
                    case "0":
                        isRunning = false;
                        Console.WriteLine("Tam biet!");
                        break;
                    default:
                        Console.WriteLine("Lua chon khong hop le, vui long chon lai.");
                        break;
                }
            }
            catch (DuplicateProductException ex)
            {
                Console.WriteLine($"[LOI] Trung ma: {ex.Message}");
            }
            catch (ProductNotFoundException ex)
            {
                Console.WriteLine($"[LOI] Khong ton tai: {ex.Message}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"[LOI] Du lieu khong hop le: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[LOI] Loi khong xac dinh: {ex.Message}");
            }

            Console.WriteLine();
        }
    }

    private static void ShowMenu()
    {
        Console.WriteLine("===== PRODUCT MANAGER =====");
        Console.WriteLine("1. Them san pham");
        Console.WriteLine("2. Xuat danh sach");
        Console.WriteLine("3. Tim theo ma");
        Console.WriteLine("4. Tim theo ten");
        Console.WriteLine("5. Loc theo khoang gia");
        Console.WriteLine("6. Xoa san pham");
        Console.WriteLine("7. Tinh tong gia tri kho");
        Console.WriteLine("0. Thoat");
        Console.Write("Chon: ");
    }

    // ---------- Các chức năng ----------

    private static void AddProduct()
    {
        string id = ReadString("Nhap ma san pham: ");
        string name = ReadString("Nhap ten san pham: ");
        decimal price = ReadDecimal("Nhap don gia: ");
        int quantity = ReadInt("Nhap so luong: ");

        Service.AddProduct(id, name, price, quantity);
    }

    private static void ShowAllProducts()
    {
        List<Product> products = Service.GetAllProducts();
        if (products.Count == 0)
        {
            Console.WriteLine("Danh sach san pham dang rong.");
            return;
        }

        PrintProducts(products);
    }

    private static void FindById()
    {
        string id = ReadString("Nhap ma san pham can tim: ");
        Product product = Service.GetProductById(id);

        PrintProducts(new List<Product> { product });
    }

    private static void FindByName()
    {
        string keyword = ReadString("Nhap tu khoa ten san pham: ");
        List<Product> result = Service.Search(keyword);

        if (result.Count == 0)
        {
            Console.WriteLine("Khong co san pham nao co ten chua tu khoa nay.");
            return;
        }

        PrintProducts(result);
    }

    private static void FilterByPriceRange()
    {
        decimal minPrice = ReadDecimal("Nhap gia nho nhat: ");
        decimal maxPrice = ReadDecimal("Nhap gia lon nhat: ");

        if (minPrice > maxPrice)
        {
            Console.WriteLine("Gia nho nhat khong duoc lon hon gia lon nhat.");
            return;
        }

        Func<Product, bool> inPriceRange = p => p.Price >= minPrice && p.Price <= maxPrice;
        List<Product> result = Service.Filter(inPriceRange);

        if (result.Count == 0)
        {
            Console.WriteLine("Khong co san pham nao trong khoang gia nay.");
            return;
        }

        PrintProducts(result);
    }

    private static void RemoveProduct()
    {
        string id = ReadString("Nhap ma san pham can xoa: ");
        Service.RemoveProduct(id);
    }

    private static void ShowTotalValue()
    {
        Console.WriteLine($"Tong gia tri kho: {Service.CalculateTotalValue():N0}");
    }

    // ---------- Hàm hỗ trợ nhập / xuất ----------

    private static void PrintProducts(List<Product> products)
    {
        Console.WriteLine($"{"Ma SP",-10} | {"Ten SP",-25} | {"Don gia",15} | {"So luong",8}");
        Console.WriteLine(new string('-', 68));
        foreach (Product product in products)
        {
            Console.WriteLine(product);
        }
    }

    /// <summary>Nhập chuỗi, lặp lại cho đến khi không rỗng.</summary>
    private static string ReadString(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();

            Console.WriteLine("Khong duoc de trong, vui long nhap lai.");
        }
    }

    /// <summary>Nhập số thực, lặp lại cho đến khi đúng định dạng.</summary>
    private static decimal ReadDecimal(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (decimal.TryParse(Console.ReadLine(), out decimal value))
                return value;

            Console.WriteLine("Gia tri phai la so, vui long nhap lai.");
        }
    }

    /// <summary>Nhập số nguyên, lặp lại cho đến khi đúng định dạng.</summary>
    private static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value))
                return value;

            Console.WriteLine("Gia tri phai la so nguyen, vui long nhap lai.");
        }
    }
}
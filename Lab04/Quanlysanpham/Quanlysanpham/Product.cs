using System.Security.Principal;

namespace ProductManager;

public class Product : IEntity
{
    private string _tenSP;
    private decimal _price;
    private int _quantity;

    public Product(string maSP, string tenSP, decimal price, int quantity)
    {
        if (string.IsNullOrWhiteSpace(maSP))
            throw new ArgumentException("Ma san pham khong duoc rong.");

        MaSP = maSP.Trim();
        _tenSP = string.Empty;

        TenSP = tenSP;      // đi qua setter để kiểm tra dữ liệu
        Price = price;
        Quantity = quantity;
    }

    public string MaSP { get; }

    /// <summary>Id dùng cho IEntity, chính là mã sản phẩm.</summary>
    public string Id => MaSP;

    public string TenSP
    {
        get => _tenSP;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Ten san pham khong duoc rong.");
            _tenSP = value.Trim();
        }
    }

    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0)
                throw new ArgumentException("Don gia khong duoc am.");
            _price = value;
        }
    }

    public int Quantity
    {
        get => _quantity;
        set
        {
            if (value < 0)
                throw new ArgumentException("So luong khong duoc am.");
            _quantity = value;
        }
    }

    /// <summary>Giá trị tồn kho của sản phẩm = đơn giá * số lượng.</summary>
    public decimal TotalValue => Price * Quantity;

    public override string ToString()
    {
        return $"{MaSP,-10} | {TenSP,-25} | {Price,15:N0} | {Quantity,8}";
    }
}
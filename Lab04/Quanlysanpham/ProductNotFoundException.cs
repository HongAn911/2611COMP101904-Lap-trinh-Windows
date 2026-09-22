namespace ProductManager;

/// <summary>Phát sinh khi tìm, sửa hoặc xóa sản phẩm không tồn tại.</summary>
public class ProductNotFoundException : Exception
{
    public string ProductId { get; }

    public ProductNotFoundException(string productId)
        : base($"Khong tim thay san pham co ma '{productId}'.")
    {
        ProductId = productId;
    }
}
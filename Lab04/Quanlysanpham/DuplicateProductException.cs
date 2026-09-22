namespace ProductManager;

/// <summary>Phát sinh khi thêm sản phẩm có mã đã tồn tại.</summary>
public class DuplicateProductException : Exception
{
    public string ProductId { get; }

    public DuplicateProductException(string productId)
        : base($"San pham co ma '{productId}' da ton tai.")
    {
        ProductId = productId;
    }
}
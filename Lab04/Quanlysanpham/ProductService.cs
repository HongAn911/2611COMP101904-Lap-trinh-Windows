namespace ProductManager;

/// <summary>
/// Xử lý nghiệp vụ quản lý sản phẩm: kiểm tra dữ liệu, gọi Repository, phát event.
/// </summary>
public class ProductService
{
    private readonly Repository<Product> _repository = new();

    // Event thông báo khi thêm / xóa sản phẩm thành công
    public event Action<Product>? ProductAdded;
    public event Action<Product>? ProductRemoved;

    public void AddProduct(string id, string name, decimal price, int quantity)
    {
        if (string.IsNullOrWhiteSpace(id))
            throw new ArgumentException("Ma san pham khong duoc rong.");

        id = id.Trim();
        if (_repository.FindById(id) != null)
            throw new DuplicateProductException(id);

        // Product tự kiểm tra tên, đơn giá, số lượng và ném ArgumentException nếu sai
        var product = new Product(id, name, price, quantity);
        _repository.Add(product);

        ProductAdded?.Invoke(product);
    }

    public void RemoveProduct(string id)
    {
        Product product = GetProductById(id);
        _repository.Remove(product.Id);

        ProductRemoved?.Invoke(product);
    }

    public Product GetProductById(string id)
    {
        Product? product = string.IsNullOrWhiteSpace(id) ? null : _repository.FindById(id.Trim());
        if (product == null)
            throw new ProductNotFoundException(id?.Trim() ?? string.Empty);

        return product;
    }

    /// <summary>Tìm theo tên chứa từ khóa (không phân biệt hoa thường).</summary>
    public List<Product> Search(string keyword)
    {
        keyword = keyword?.Trim() ?? string.Empty;
        return Filter(p => p.TenSP.Contains(keyword, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>Lọc sản phẩm theo điều kiện bất kỳ bằng Func.</summary>
    public List<Product> Filter(Func<Product, bool> condition)
    {
        return _repository.Find(condition);
    }

    public List<Product> GetAllProducts()
    {
        return _repository.GetAll();
    }

    public decimal CalculateTotalValue()
    {
        return _repository.GetAll().Sum(p => p.TotalValue);
    }
}
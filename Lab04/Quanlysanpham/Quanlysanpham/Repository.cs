namespace ProductManager;

/// <summary>
/// Kho lưu trữ generic trong bộ nhớ cho mọi kiểu T có Id.
/// </summary>
public class Repository<T> where T : IEntity
{
    private readonly List<T> _items = new();

    public void Add(T item)
    {
        ArgumentNullException.ThrowIfNull(item);
        _items.Add(item);
    }

    /// <summary>Xóa phần tử theo Id. Trả về true nếu xóa được.</summary>
    public bool Remove(string id)
    {
        T? item = FindById(id);
        return item != null && _items.Remove(item);
    }

    /// <summary>Tìm theo Id (không phân biệt hoa thường). Không thấy thì trả về null.</summary>
    public T? FindById(string id)
    {
        return _items.FirstOrDefault(
            x => string.Equals(x.Id, id, StringComparison.OrdinalIgnoreCase));
    }

    /// <summary>Tìm tất cả phần tử thỏa điều kiện.</summary>
    public List<T> Find(Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return _items.Where(predicate).ToList();
    }

    public List<T> GetAll()
    {
        return new List<T>(_items);
    }
}
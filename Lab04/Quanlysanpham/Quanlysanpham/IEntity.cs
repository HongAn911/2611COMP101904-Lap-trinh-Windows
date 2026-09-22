namespace ProductManager;

/// <summary>
/// Ràng buộc generic cho Repository&lt;T&gt;: mọi đối tượng lưu trong Repository phải có Id.
/// </summary>
public interface IEntity
{
    string Id { get; }
}
namespace ShopManagerMini.Models
{
    /// <summary>
    /// Sản phẩm của cửa hàng mini.
    /// </summary>
    public class Product
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public Product()
        {
        }

        public Product(string productId, string productName, string category, decimal price, int quantity)
        {
            ProductId = productId;
            ProductName = productName;
            Category = category;
            Price = price;
            Quantity = quantity;
        }
    }
}

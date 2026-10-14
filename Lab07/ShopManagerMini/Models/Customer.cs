namespace ShopManagerMini.Models
{
    /// <summary>
    /// Khách hàng của cửa hàng mini.
    /// </summary>
    public class Customer
    {
        public string CustomerId { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string CustomerType { get; set; }

        public Customer()
        {
        }

        public Customer(string customerId, string fullName, string phone, string customerType)
        {
            CustomerId = customerId;
            FullName = fullName;
            Phone = phone;
            CustomerType = customerType;
        }
    }
}

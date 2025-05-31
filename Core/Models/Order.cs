using System;
namespace AWEElectronicsBlazorApp.Core.Models
{
    public class Order
    {
        public string OrderId { get; }
        public Customer Customer { get; }
        public Dictionary<Product, int> Products { get; }
        public decimal TotalCost { get; } 
        public DateTime OrderDate { get; }
        public string Status { get; set; } = "Pending Payment";

        public Order(Customer customer, Dictionary<Product, int> products)
        {
            OrderId = Guid.NewGuid().ToString();
            Customer = customer;
            Products = products;
            TotalCost = products.Sum(item => item.Key.Price * item.Value);
            OrderDate = DateTime.Now;
        }

        public override string ToString()
        {
            var items = string.Join("\n  ", Products.Select(p => $"{p.Value} x {p.Key.Name} @ ${p.Key.Price:F2}"));
            return $"--- Order {OrderId} ---\n" +
                   $"Customer: {Customer.Name}\n" +
                   $"Date: {OrderDate}\n" +
                   $"Items:\n  {items}\n" +
                   $"Total: ${TotalCost:F2}\n" +
                   $"Status: {Status}\n" +
                   $"----------------------";
        }
    }
}

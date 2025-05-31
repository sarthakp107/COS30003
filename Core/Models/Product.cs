using System;
namespace AWEElectronicsBlazorApp.Core.Models
{
    // Represents an item for sale [cite: 81, 116]
    public class Product
    {
        public string ProductId { get; }
        public string Name { get; set; }
        public string Description { get; set; } // [cite: 116]
        public decimal Price { get; set; } // [cite: 116]
        public string Category { get; set; } // Merged category info

        public Product(string name, string description, decimal price, string category)
        {
            ProductId = Guid.NewGuid().ToString();
            Name = name;
            Description = description;
            Price = price;
            Category = category;
        }

        public override string ToString()
        {
            return $"{Name} ({Category}) - ${Price:F2} - {Description}";
        }
    }
}
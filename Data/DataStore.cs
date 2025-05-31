using AWEElectronicsBlazorApp.Core.Models;

namespace AWEElectronicsBlazorApp.Data
{
    public static class DataStore
    {
        public static List<User> Users { get; } = new List<User>();
        public static List<Product> Products { get; } = new List<Product>();
        public static Dictionary<Product, int> Stock { get; } = new Dictionary<Product, int>();
        public static List<Transaction> Transactions { get; } = new List<Transaction>();
        public static List<Receipt> Receipts { get; } = new List<Receipt>();
        public static List<Order> Orders { get; } = new List<Order>();

        private static bool isInitialized = false;
        private static readonly object _lock = new object();

        public static void InitializeData()
        {
            lock (_lock)
            {
                if (isInitialized) return;

                // Users
                Users.Add(new Customer("Sarthak Pradhan", "sarthak@email.com", "pass1"));
                Users.Add(new Admin("Prabesh Bhattarai", "prabesh@email.com", "admin1"));
                Users.Add(new Customer("Nisha Khadka", "nisha@email.com", "pass2"));
                Users.Add(new Customer("Aayush Gurung", "aayush@email.com", "pass3"));
                Users.Add(new Customer("Reema Acharya", "reema@email.com", "pass4"));
                Users.Add(new Customer("Bibek Singh", "bibek@email.com", "pass5"));
                Users.Add(new Admin("Dipika Sharma", "dipika@email.com", "admin2"));
                Users.Add(new Customer("Kripa Karki", "kripa@email.com", "pass6"));

                // Products
                void AddProduct(string name, string desc, decimal price, string category, int stock)
                {
                    var p = new Product(name, desc, price, category);
                    Products.Add(p);
                    Stock[p] = stock;
                }

                AddProduct("Laptop Pro X", "High-performance laptop", 1500.00m, "Computers", 15);
                AddProduct("Wireless Mouse G", "Ergonomic wireless mouse", 75.50m, "Accessories", 50);
                AddProduct("4K Monitor 27", "27-inch 4K UHD Monitor", 650.00m, "Displays", 10);
                AddProduct("Mechanical Keyboard", "RGB Mechanical Keyboard", 120.00m, "Accessories", 30);
                AddProduct("Gaming Headset", "Surround sound gaming headset", 89.99m, "Audio", 25);
                AddProduct("Smartphone Z12", "Latest gen smartphone with OLED", 999.99m, "Mobile", 20);
                AddProduct("Portable SSD 1TB", "High-speed external SSD", 139.99m, "Storage", 40);
                AddProduct("USB-C Dock", "Multi-port USB-C docking station", 89.99m, "Accessories", 35);


                isInitialized = true;
                Console.WriteLine("Static In-memory data store initialized with extended sample data.");
            }
        }
    }
}

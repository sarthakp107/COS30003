using AWEElectronicsBlazorApp.Core.Models;
using AWEElectronicsBlazorApp.Data; // Ensure using

namespace AWEElectronicsBlazorApp.Core.Services
{
    // Manages product stock (Singleton managed by DI)
    public class Inventory
    {
        // Removed Lazy<T> and Instance - DI handles this now.

        // Internal reference to static data
        private readonly Dictionary<Product, int> _stockLevels = DataStore.Stock;

        // << CONSTRUCTOR MADE PUBLIC >>
        public Inventory()
        {
            Console.WriteLine("Inventory Singleton Instance Created by DI.");
        }

        public int GetStockLevel(Product product)
        {
            return _stockLevels.TryGetValue(product, out int stock) ? stock : 0;
        }

        public bool CheckStock(Product product, int quantity)
        {
            return GetStockLevel(product) >= quantity;
        }

        public bool ReduceStock(Product product, int quantity)
        {
            if (CheckStock(product, quantity))
            {
                _stockLevels[product] -= quantity;
                return true;
            }
            return false;
        }

        public void IncreaseStock(Product product, int quantity)
        {
            if (_stockLevels.ContainsKey(product))
            {
                _stockLevels[product] += quantity;
            }
            else
            {
                _stockLevels[product] = quantity;
            }
        }
    }
}
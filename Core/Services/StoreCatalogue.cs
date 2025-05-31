using AWEElectronicsBlazorApp.Core.Models;
using AWEElectronicsBlazorApp.Data; // Ensure using

namespace AWEElectronicsBlazorApp.Core.Services
{
    // Manages product listings (Singleton managed by DI)
    public class StoreCatalogue
    {
        // Removed Lazy<T> and Instance - DI handles this now.

        // << Injected Inventory >>
        private readonly Inventory _inventory;

        // << CONSTRUCTOR MADE PUBLIC and INJECTS Inventory >>
        public StoreCatalogue(Inventory inventory)
        {
            _inventory = inventory; // Store the injected instance
            Console.WriteLine("StoreCatalogue Singleton Instance Created by DI.");
        }

        public List<Product> GetAllProducts()
        {
            return DataStore.Products; // Accessing static DataStore
        }

        // We can now use the injected _inventory instance
        public int GetProductStock(Product product)
        {
            return _inventory.GetStockLevel(product);
        }

        public Product? GetProductByIndex(int index)
        {
            if (index >= 0 && index < DataStore.Products.Count)
            {
                return DataStore.Products[index];
            }
            return null;
        }

        public void AddProduct(Product product)
        {
            DataStore.Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            DataStore.Products.Remove(product);
        }
    }
}
using AWEElectronicsBlazorApp.Core.Models; // Ensure using if not already present

namespace AWEElectronicsBlazorApp.Core.Models
{
    // Manages selected products for a customer
    public class ShoppingCart
    {
        public Customer Owner { get; }
        public Dictionary<Product, int> Items { get; } = new Dictionary<Product, int>();

        public ShoppingCart(Customer owner)
        {
            Owner = owner;
        }

        public void AddProduct(Product product, int quantity)
        {
            if (quantity <= 0) return; // Simplified

            if (Items.ContainsKey(product))
            {
                Items[product] += quantity;
            }
            else
            {
                Items[product] = quantity;
            }
        }

        public void RemoveProduct(Product product, int quantity)
        {
            if (!Items.ContainsKey(product) || quantity <= 0) return; // Simplified

            if (Items[product] <= quantity)
            {
                Items.Remove(product);
            }
            else
            {
                Items[product] -= quantity;
            }
        }

        public decimal GetTotalCost()
        {
            return Items.Sum(item => item.Key.Price * item.Value);
        }

        public void ClearCart()
        {
            Items.Clear();
        }

        // << RETURN TYPE CHANGED TO Order? >>
        public Order? ProceedToCheckout()
        {
            if (!Items.Any())
            {
                // Console.WriteLine("Cannot proceed to checkout, cart is empty."); // UI will handle msg
                return null; // << This is now valid because of Order?
            }
            return new Order(Owner, new Dictionary<Product, int>(Items));
        }
    }
}
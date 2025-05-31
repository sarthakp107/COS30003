using AWEElectronicsBlazorApp.Core.Models;

namespace AWEElectronicsBlazorApp.Services
{
    // Manages the state for the current user's session (Scoped)
    public class UserSessionService
    {
        public User? CurrentUser { get; private set; }
        public ShoppingCart? CurrentCart => (CurrentUser as Customer)?.Cart;

        public event Action? OnChange; // Event to notify components of changes


        public Receipt? LastReceipt { get; private set; }


        public void SetCurrentUser(User? user)
        {
            CurrentUser = user;
            NotifyStateChanged();
        }

        public bool IsLoggedIn => CurrentUser != null;
        public bool IsCustomer => CurrentUser is Customer;
        public bool IsAdmin => CurrentUser is Admin;

        private void NotifyStateChanged() => OnChange?.Invoke();

        // Cart Actions - Delegate to Cart or add here
        public void AddToCart(Product product, int quantity)
        {
            CurrentCart?.AddProduct(product, quantity);
            NotifyStateChanged();
        }

        public void RemoveFromCart(Product product, int quantity)
        {
            CurrentCart?.RemoveProduct(product, quantity);
            NotifyStateChanged();
        }

        public void ClearCart()
        {
            CurrentCart?.ClearCart();
            NotifyStateChanged();
        }

        public void SetLastReceipt(Receipt receipt)
        {
            LastReceipt = receipt;
            NotifyStateChanged();
        }
    }
}
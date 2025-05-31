using System;
namespace AWEElectronicsBlazorApp.Core.Models
{
   public class Customer : User
    {
        public ShoppingCart Cart { get; }

        public Customer(string name, string email, string password)
            : base(name, email, password)
        {
            Cart = new ShoppingCart(this); 
        }

        public override string GetUserType() => "Customer";
        
        public void PlaceOrder() { /* UI will handle flow to Order */ } 
        public void ViewOrderHistory() { /* Future task */ }
    }
}
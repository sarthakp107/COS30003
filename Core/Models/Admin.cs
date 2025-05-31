using System;
namespace AWEElectronicsBlazorApp.Core.Models
{
    // Represents an admin/store manager [cite: 81, 84, 114]
    public class Admin : User
    {
        public Admin(string name, string email, string password)
            : base(name, email, password)
        {
        }

        public override string GetUserType() => "Admin";

        // Methods specific to Admin [cite: 115]
        public void UpdateCatalogue() { /* Future task */ } // [cite: 115]
        public void ManageInventory() { /* Future task */ } // [cite: 115]
        public void AnalyzeSales() { /* Future task */ } // [cite: 115]
        public void ViewReport()
        {
            Console.Write("Report");
        }
    }
}
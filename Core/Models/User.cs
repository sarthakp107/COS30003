using System;
namespace AWEElectronicsBlazorApp.Core.Models
{
    // Abstract base class for users [cite: 80, 110]
    public abstract class User
    {
        public string UserId { get; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; private set; } // Keep password private

        protected User(string name, string email, string password)
        {
            UserId = Guid.NewGuid().ToString();
            Name = name;
            Email = email;
            Password = password;
        }

        // Handles user authentication [cite: 112]
        public bool Authenticate(string password)
        {
            return Password == password;
        }

        public abstract string GetUserType();
    }
}

using AWEElectronicsBlazorApp.Core.Models;
using AWEElectronicsBlazorApp.Data; 

namespace AWEElectronicsBlazorApp.Core.Services
{
    public class UserService
    {
    

        public User CreateUser(string type, string name, string email, string password)
        {
            User newUser;
            if (type.Equals("Customer", StringComparison.OrdinalIgnoreCase))
            {
                newUser = new Customer(name, email, password);
            }
            else if (type.Equals("Admin", StringComparison.OrdinalIgnoreCase))
            {
                newUser = new Admin(name, email, password);
            }
            else
            {
                throw new ArgumentException("Invalid user type specified.");
            }

            // << Accessing static DataStore >>
            if (DataStore.Users.Any(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"User with email {email} already exists.");
            }

            DataStore.Users.Add(newUser); // << Accessing static DataStore >>
            Console.WriteLine($"{type} user '{name}' created successfully.");
            return newUser;
        }

        public User? Login(string email, string password)
        {
            // << Accessing static DataStore >>
            var user = DataStore.Users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));

            if (user != null && user.Authenticate(password))
            {
                Console.WriteLine($"Welcome back, {user.Name} ({user.GetUserType()})!");
                return user;
            }


            return null;
        }

    }
}
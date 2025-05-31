using AWEElectronicsBlazorApp.Core.Interfaces;

namespace AWEElectronicsBlazorApp.Core.Implementations
{
    public class PayPalPayment : IPaymentMethod
    {
        public string Name => "PayPal";

        public bool ProcessPayment(decimal amount)
        {
            // Simulate payment processing for CLI
            Console.WriteLine($"Simulating PayPal payment for ${amount:F2}...");
            Console.Write("Enter 'Y' to simulate success, anything else for failure: ");
            string input = Console.ReadLine() ?? "";
            bool success = input.Equals("Y", StringComparison.OrdinalIgnoreCase);
            Console.WriteLine(success ? "PayPal payment successful." : "PayPal payment failed.");
            return success;
        }
    }
}
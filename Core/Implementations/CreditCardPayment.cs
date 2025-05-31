using AWEElectronicsBlazorApp.Core.Interfaces;


namespace AWEElectronicsBlazorApp.Core.Implementations
{
    public class CreditCardPayment : IPaymentMethod
    {
        public string Name => "Credit Card";
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Initiating Credit Card payment for ${amount:F2}...");
            return true; // Assume initiation is always possible.
        }
    }
}
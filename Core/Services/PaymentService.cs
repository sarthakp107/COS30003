using AWEElectronicsBlazorApp.Core.Models;
using AWEElectronicsBlazorApp.Core.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AWEElectronicsBlazorApp.Core.Services
{
    // Handles the overall payment process
    public class PaymentService
    {
        public Transaction Process(Order order, IPaymentMethod paymentMethod) // [cite: 127]
        {
            Console.WriteLine($"Processing payment for Order {order.OrderId} using {paymentMethod.Name}...");

            bool success = paymentMethod.ProcessPayment(order.TotalCost); // Call strategy [cite: 127]

            string message = success ? "Payment completed successfully." : "Payment failed.";
            var transaction = new Transaction(order.OrderId, order.TotalCost, success, paymentMethod.Name, message); // [cite: 128]

            Data.DataStore.Transactions.Add(transaction); // Store transaction
            Console.WriteLine(transaction);

            if (success)
            {
                order.Status = "Payment Successful - Awaiting Shipment";
                var receipt = new Receipt(transaction); // [cite: 129]
                Data.DataStore.Receipts.Add(receipt); // Store receipt
                Console.WriteLine(receipt);
                // In a real app, update inventory here or have Order do it.
            }
            else
            {
                order.Status = "Payment Failed";
            }

            return transaction;
        }
    }
}
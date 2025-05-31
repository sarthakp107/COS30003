using System;
namespace AWEElectronicsBlazorApp.Core.Models
{
    // Records a payment attempt [cite: 80, 128]
    public class Transaction
    {
        public string TransactionId { get; }
        public string OrderId { get; }
        public decimal Amount { get; }
        public DateTime TransactionDate { get; }
        public bool IsSuccess { get; } // [cite: 128]
        public string PaymentMethod { get; }
        public string Message { get; }

        public Transaction(string orderId, decimal amount, bool isSuccess, string paymentMethod, string message)
        {
            TransactionId = Guid.NewGuid().ToString();
            OrderId = orderId;
            Amount = amount;
            TransactionDate = DateTime.Now;
            IsSuccess = isSuccess;
            PaymentMethod = paymentMethod;
            Message = message;
        }

        public override string ToString()
        {
            return $"Transaction {TransactionId} ({TransactionDate}): Order {OrderId}, Amount ${Amount:F2}, Method: {PaymentMethod}, Status: {(IsSuccess ? "Success" : "Failed")}, Msg: {Message}";
        }
    }
}
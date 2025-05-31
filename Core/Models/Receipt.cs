using System;
namespace AWEElectronicsBlazorApp.Core.Models
{
    // Confirmation for a successful transaction [cite: 80, 129]
    public class Receipt
    {
        public string ReceiptId { get; }
        public string OrderId { get; }
        public string TransactionId { get; }
        public DateTime IssueDate { get; }
        public decimal AmountPaid { get; }

        public Receipt(Transaction transaction)
        {
            if (!transaction.IsSuccess)
                throw new ArgumentException("Cannot create a receipt for a failed transaction."); // [cite: 37]

            ReceiptId = $"REC-{Guid.NewGuid().ToString().Substring(0, 8).ToUpper()}";
            OrderId = transaction.OrderId;
            TransactionId = transaction.TransactionId;
            IssueDate = DateTime.Now;
            AmountPaid = transaction.Amount;
        }

        public override string ToString()
        {
            return $"--- RECEIPT {ReceiptId} ---\n" +
                  $"Date: {IssueDate}\n" +
                  $"Order ID: {OrderId}\n" +
                  $"Transaction ID: {TransactionId}\n" +
                  $"Amount Paid: ${AmountPaid:F2}\n" +
                  $"--- Thank You! ---";
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace weight_wise_Invoice.Models
{
    public class WeightPaymentData
    {
        public int InvoiceId { get; set; }
        public string CustomerName { get; set; }
        public DateTime? Date { get; set; } // Nullable DateTime to avoid null errors
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string CardNumber { get; set; }
        public string TransactionId { get; set; }
        public string Address { get; set; }
        public DateTime? DueDate { get; set; } // Nullable for optional due date
    }
}
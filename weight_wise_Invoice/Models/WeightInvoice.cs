using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace weight_wise_Invoice.Models
{
    public class WeightInvoice
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Date { get; set; }
        public string Weight { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalAmount { get; set; }
        public object PaymentMethod { get; internal set; }
    }
}
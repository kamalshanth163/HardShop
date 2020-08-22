using System;

namespace HardShop_API.Models
{
    public class PurchaseOrderPayment
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Method { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public double Fee { get; set; }

    }
}
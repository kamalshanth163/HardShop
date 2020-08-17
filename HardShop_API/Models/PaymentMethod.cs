using System.Collections.Generic;

namespace HardShop_API.Models
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Method { get; set; }
        public ICollection<SalesOrderPayment> SalesOrderPayments { get; set; }
        public ICollection<PurchaseOrderPayment> PurchaseOrderPayments { get; set; }
    }
}
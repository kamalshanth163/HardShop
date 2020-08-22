using System;
using System.Collections.Generic;

namespace HardShop_API.Models
{
    public class Card
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Number { get; set; }
        public string Holder { get; set; }
        public string Issuer { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime Created { get; set; }
        public ICollection<CustomerCard> CustomerCards { get; set; }
        public ICollection<AdminCard> AdminCards { get; set; }
        public ICollection<SalesOrder> SalesOrders { get; set; }
        public ICollection<SalesOrderPayment> SalesOrderPayments { get; set; }
        public ICollection<PurchaseOrderPayment> PurchaseOrderPayments { get; set; }

    }
}
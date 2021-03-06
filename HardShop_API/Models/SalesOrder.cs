using System;
using System.Collections.Generic;

namespace HardShop_API.Models
{
    public class SalesOrder
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public DateTime Delivered { get; set; }
        public double GrossAmount { get; set; }
        public double Discount { get; set; }
        public double NetAmount { get; set; }
        public double TotalPayment { get; set; }
        public double Arrears { get; set; }
        public double TotalFee { get; set; }
        public ICollection<SalesOrderList> SalesOrderLists { get; set; }
        public ICollection<SalesOrderPayment> SalesOrderPayments { get; set; }
        public ICollection<SalesOrderOperation> SalesOrderOperations { get; set; }
    }
}
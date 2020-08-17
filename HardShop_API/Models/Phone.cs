using System.Collections.Generic;

namespace HardShop_API.Models
{
    public class Phone
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string DialCode { get; set; }
        public string e164Number { get; set; }
        public string IntlNumber { get; set; }
        public string NatlNumber { get; set; }
        public string Number { get; set; }
        public ICollection<CustomerPhone> CustomerPhones { get; set; }
        public ICollection<SupplierPhone> SupplierPhones { get; set; }
        public ICollection<SalesOrder> SalesOrders { get; set; }

    }
}
using System.Collections.Generic;

namespace HardShop_API.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public ICollection<SupplierAddress> SupplierAddresses { get; set; }
        public ICollection<SalesOrder> SalesOrders { get; set; }

    }
}
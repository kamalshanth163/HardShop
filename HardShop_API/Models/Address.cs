using System;
using System.Collections.Generic;

namespace HardShop_API.Models {
    public class Address {
        public int Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }

        public ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public ICollection<AdminAddress> AdminAddresses { get; set; }
        public ICollection<SupplierDetail> SupplierDetails { get; set; }
        public ICollection<SalesOrder> SalesOrders { get; set; }

    }
}


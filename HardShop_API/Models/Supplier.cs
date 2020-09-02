using System;
using System.Collections.Generic;

namespace HardShop_API.Models {
    public class Supplier {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string PhotoUrl { get; set; }
        public string PhotoPublicId { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }

        public ICollection<SupplierDetail> SupplierDetails { get; set; }
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
    }
}
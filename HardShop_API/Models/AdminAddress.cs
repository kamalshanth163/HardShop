using System;

namespace HardShop_API.Models {
    public class AdminAddress {
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public DateTime Created { get; set; }

    }
}
using System;

namespace HardShop_API.Models {
    public class AdminPhone {
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public int PhoneId { get; set; }
        public Phone Phone { get; set; }

        public DateTime Created { get; set; }

    }
}
using System.Collections.Generic;

namespace HardShop_API.Models {
    public class Brand {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public ICollection<Product> Products { get; set; }

    }
}
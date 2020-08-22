using System;
using System.Collections.Generic;

namespace HardShop_API.Models {
    public class Product {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }

        public int CategoryId { get; set; }
        public ProductCategory Category { get; set; }

        public ICollection<ProductOption> ProductOptions { get; set; }
    }
}
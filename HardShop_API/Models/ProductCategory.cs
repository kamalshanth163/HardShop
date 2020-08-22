using System;
using System.Collections.Generic;

namespace HardShop_API.Models {
    public class ProductCategory {
        public int Id { get; set; }
        public string MainCategory { get; set; }
        public string SubCategory1 { get; set; }
        public string SubCategory2 { get; set; }
        public DateTime Created { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
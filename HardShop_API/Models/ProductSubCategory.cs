using System;
using System.Collections.Generic;

namespace HardShop_API.Models
{
    public class ProductSubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }

        public int MainCategoryId { get; set; }
        public ProductMainCategory MainCategory { get; set; }
        
        public ICollection<Product> Products { get; set; }
    }
}
using System;
using System.Collections.Generic;

namespace HardShop_API.Models
{
    public class ProductMainCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public ICollection<ProductSubCategory> ProductSubCategories { get; set; }
    }
}
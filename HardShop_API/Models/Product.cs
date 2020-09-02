using System;
using System.Collections.Generic;

namespace HardShop_API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }

        public int SubCategoryId { get; set; }
        public ProductSubCategory SubCategory { get; set; }

        public ICollection<ProductOption> ProductOptions { get; set; }
    }
}
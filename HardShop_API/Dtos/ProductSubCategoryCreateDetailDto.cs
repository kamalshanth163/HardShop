using System;
using System.ComponentModel.DataAnnotations;

namespace HardShop_API.Dtos {
    public class ProductSubCategoryCreateDetailDto {
        [Required]
        public string MainCategory { get; set; }

        [Required]
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }

        public ProductSubCategoryCreateDetailDto () {
            Created = DateTime.Now;
            LastUpdated = DateTime.Now;
        }
    }
}
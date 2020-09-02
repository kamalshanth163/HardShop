using System;
using System.ComponentModel.DataAnnotations;

namespace HardShop_API.Dtos {
    public class ProductSubCategoryCreateDto {

        [Required]
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }

        public ProductSubCategoryCreateDto () {
            Created = DateTime.Now;
            LastUpdated = DateTime.Now;
        }
    }
}
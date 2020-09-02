using System;
using System.ComponentModel.DataAnnotations;

namespace HardShop_API.Dtos {
    public class ProductCreateDetailDto {

        [Required]
        public string MainCategory { get; set; }

        [Required]
        public string SubCategory { get; set; }


        [Required]
        public string Name { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        public string Color { get; set; }

        [Required]
        public string Currency { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public double Discount { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string Status { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }

        public ProductCreateDetailDto () {
            Created = DateTime.Now;
            LastUpdated = DateTime.Now;
        }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace HardShop_API.Dtos
{
    public class ProductOptionCreateDto
    {
        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Size { get; set; }

        [Required]
        public string Color { get; set; }

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
        public DateTime Created { get; set; }

        public ProductOptionCreateDto()
        {
            Created = DateTime.Now;
        }
    }
}
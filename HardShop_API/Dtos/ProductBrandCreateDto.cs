using System;
using System.ComponentModel.DataAnnotations;

namespace HardShop_API.Dtos
{
    public class ProductBrandCreateDto
    {
        [Required]
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public ProductBrandCreateDto()
        {
            Created = DateTime.Now;
        }
    }
}
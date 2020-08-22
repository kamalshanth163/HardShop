using System;
using System.ComponentModel.DataAnnotations;

namespace HardShop_API.Dtos
{
    public class ProductCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Created { get; set; }
        public ProductCategoryCreateDto ProductCategory { get; set; }
        public ProductOptionCreateDto ProductOption { get; set; }

        public ProductCreateDto()
        {
            Created = DateTime.Now;
        }
    }
}
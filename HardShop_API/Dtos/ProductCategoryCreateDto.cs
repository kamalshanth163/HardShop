using System;
using System.ComponentModel.DataAnnotations;

namespace HardShop_API.Dtos
{
    public class ProductCategoryCreateDto
    {
        [Required]
        public string MainCategory { get; set; }

        [Required]
        public string SubCategory1 { get; set; }

        [Required]
        public string SubCategory2 { get; set; }
        public DateTime Created { get; set; }
        public ProductCategoryCreateDto()
        {
            Created = DateTime.Now;
        }
    }
}
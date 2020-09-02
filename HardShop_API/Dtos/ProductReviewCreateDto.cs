using System;

namespace HardShop_API.Dtos
{
    public class ProductReviewCreateDto
    {
        public string Review { get; set; }
        public float Rating { get; set; }
        public DateTime Date { get; set; }
        public ProductReviewCreateDto()
        {
            Date = DateTime.Now;
        }
    }
}
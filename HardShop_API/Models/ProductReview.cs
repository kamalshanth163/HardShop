using System;

namespace HardShop_API.Models
{
    public class ProductReview
    {
        public int ProductOptionId { get; set; }
        public ProductOption ProductOption { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Review { get; set; }
        public float Rating { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }

    }
}
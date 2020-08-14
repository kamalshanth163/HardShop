using System;

namespace HardShop_API.Models
{
    public class ProductReview
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public string Review { get; set; }
        public DateTime Date { get; set; }
    }
}
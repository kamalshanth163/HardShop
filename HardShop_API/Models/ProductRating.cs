using System;

namespace HardShop_API.Models
{
    public class ProductRating
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public float Rating { get; set; }
        public DateTime Date { get; set; }
    }
}
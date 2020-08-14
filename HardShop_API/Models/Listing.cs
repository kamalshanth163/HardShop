using System.Collections.Generic;

namespace HardShop_API.Models
{
    public class Listing
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
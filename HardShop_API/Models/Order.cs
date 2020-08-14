using System;
using System.Collections.Generic;

namespace HardShop_API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime Created { get; set; }
        public DateTime Delivery { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public double Amount { get; set; }
        public double Discount { get; set; }
        public double Fee { get; set; }
        public double Payment { get; set; }
        public ICollection<Listing> Listings { get; set; }
        public ICollection<OrderOperation> OrderOperations { get; set; }

    }
}
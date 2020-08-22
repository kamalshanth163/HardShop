using System;
using System.Collections.Generic;

namespace HardShop_API.Models {
    public class ProductOption {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<ProductOperation> ProductOperations { get; set; }
        public ICollection<ProductReview> ProductReviews { get; set; }
    }
}
using System.Collections.Generic;

namespace HardShop_API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Brand Brand { get; set; }
        public int BrandId { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public ICollection<Model> Models { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public ICollection<ProductOperation> ProductOperations { get; set; }
        public ICollection<ProductReview> ProductReviews { get; set; }
        public ICollection<ProductRating> ProductRatings { get; set; }

    }
}
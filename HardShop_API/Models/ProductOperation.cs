using System;

namespace HardShop_API.Models
{
    public class ProductOperation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public int MemberId { get; set; }
        public string MemberRole { get; set; }
        public int ProductOptionId { get; set; }
        public ProductOption ProductOption { get; set; }
    }
}
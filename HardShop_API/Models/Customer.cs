using System;
using System.Collections.Generic;

namespace HardShop_API.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Role { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }

        public DateTime LastActive { get; set; }
        public string PhotoUrl { get; set; }
        public string PhotoPublicId { get; set; }
        public ICollection<ProductReview> ProductReviews { get; set; }
        public ICollection<CustomerPhone> CustomerPhones { get; set; }
        public ICollection<CustomerAddress> CustomerAddresses { get; set; }
        public ICollection<CustomerCard> CustomerCards { get; set; }
        public ICollection<SalesOrder> SalesOrder { get; set; }

    }
}
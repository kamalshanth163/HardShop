using System;
using System.Collections.Generic;

namespace HardShop_API.Models
{
    public class Admin
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
        public ICollection<SalesOrder> SalesOrder { get; set; }
        public ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public ICollection<AdminPhone> AdminPhones { get; set; }
        public ICollection<AdminAddress> AdminAddresses { get; set; }
        public ICollection<AdminCard> AdminCards { get; set; }

    }
}
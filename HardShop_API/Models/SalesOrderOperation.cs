using System;

namespace HardShop_API.Models
{
    public class SalesOrderOperation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
        public string MemberRole { get; set; }
    }
}
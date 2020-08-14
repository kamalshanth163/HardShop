using System;

namespace HardShop_API.Models
{
    public class ProductOperation
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public DateTime Date { get; set; }
        public int MemberId { get; set; }
        public string MemberRole { get; set; }
    }
}
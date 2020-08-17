using System;
using System.Collections.Generic;

namespace HardShop_API.Models
{
    public class CardNetwork
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public ICollection<Card> Cards { get; set; }
    }
}
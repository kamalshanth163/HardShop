using System;

namespace HardShop_API.Models
{
    public class AdminCard
    {
        public int AdminId { get; set; }
        public Admin Admin { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }

        public DateTime Created { get; set; }
        
        

    }
}
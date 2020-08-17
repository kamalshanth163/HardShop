namespace HardShop_API.Models
{
    public class CustomerCard
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
namespace HardShop_API.Models
{
    public class SupplierCard
    {
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int CardId { get; set; }
        public Card Card { get; set; }
    }
}
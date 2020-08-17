namespace HardShop_API.Models
{
    public class SupplierPhone
    {
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
    }
}
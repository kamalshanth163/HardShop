namespace HardShop_API.Models
{
    public class CustomerPhone
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
    }
}
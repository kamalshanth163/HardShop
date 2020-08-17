namespace HardShop_API.Models
{
    public class PurchaseOrderList
    {
        public int PurchaseOrderId { get; set; }
        public PurchaseOrder PurchaseOrder { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
        public double UnitDiscount { get; set; }
        public double TotalDiscount { get; set; }
    }
}
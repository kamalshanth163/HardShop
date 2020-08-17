using System.Collections.Generic;

namespace HardShop_API.Models
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public int Quantity { get; set; }
        public string Status { get; set; }
        public int ModelId { get; set; }
        public Model Model { get; set; }
        public ICollection<SalesOrderList> SalesOrderLists { get; set; }
        public ICollection<PurchaseOrderList> PurchaseOrderLists { get; set; }
    }
}
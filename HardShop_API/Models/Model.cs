using System.Collections.Generic;

namespace HardShop_API.Models {
    public class Model {
        public int Id { get; set; }
        public string Name { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public ICollection<Size> Sizes { get; set; }
    }
}
namespace HardShop_API.Models {
    public class Photo {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
        public int ProductOptionId { get; set; }
        public ProductOption ProductOption { get; set; }
    }
}
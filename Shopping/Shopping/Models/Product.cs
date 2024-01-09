namespace Shopping.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
    }
}

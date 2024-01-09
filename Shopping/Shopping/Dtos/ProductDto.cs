namespace Shopping.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class ProductListDto 
    {
        public List<ProductDto> Products { get; set; }
    }
    public class CreateOrderDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}

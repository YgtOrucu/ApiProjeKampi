namespace ApiProjeKampi.WebUI.Dtos.ProductDto
{
    public class CreateProductWithCategoryDto
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
    }
}

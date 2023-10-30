using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.Dtos.Responses.Product
{
    public class ProductGetByCategoryResponseDto
    {
        public IEnumerable<ProductData> Products { get; set; }
    }

    public class ProductData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ProductImageUrl { get; set; }
    }
}

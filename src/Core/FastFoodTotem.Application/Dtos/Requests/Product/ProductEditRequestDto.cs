using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.Dtos.Requests.Product
{
    public class ProductEditRequestDto : ApiBaseRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CategoryType Type { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ProductImageUrl { get; set; }
    }
}

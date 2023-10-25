using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.Dtos.Requests.Product
{
    public class ProductCreateRequestDto : ApiBaseRequest
    {
        public string Name { get; set; }
        public CategoryType Type { get; set; }
        public decimal Price { get; set; }
    }
}

using FastFoodTotem.Application.DtoValidators;

namespace FastFoodTotem.Application.Dtos.Requests.Order
{
    public struct OrderItemAddRequestDto
    {
        [GuidNotEmpty(ErrorMessage = "Invalid product Id!")]
        public Guid Id { get; set; }
    }
}

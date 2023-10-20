using FastFoodTotem.Application.DtoValidators;

namespace FastFoodTotem.Application.Dtos.Requests.Order
{
    public struct OrderCreateRequestDto
    {
        public Guid CustomerId { get; set; }

        [ListCountValidation(ErrorMessage = "Order need at least one product to be created!")]
        public IList<OrderItemAddRequestDto> Items { get; set; }
    }
}

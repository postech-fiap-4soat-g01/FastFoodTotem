using FastFoodTotem.Application.DtoValidators;
using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.Dtos.Requests.Order
{
    public class OrderCreateRequestDto : ApiBaseRequest
    {
        public Guid CustomerId { get; set; }
        public OrderStatus Status { get; set; }

        [ListCountValidation(ErrorMessage = "Order need at least one product to be created!")]
        public IList<OrderItemAddRequestDto> Items { get; set; }
    }
}

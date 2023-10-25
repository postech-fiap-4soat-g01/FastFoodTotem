using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.Dtos.Requests.Order
{
    public class OrderCreateRequestDto : ApiBaseRequest
    {
        public int CustomerId { get; set; }
        public OrderStatus Status { get; set; }
        public IList<OrderItemAddRequestDto> Items { get; set; }
    }
}

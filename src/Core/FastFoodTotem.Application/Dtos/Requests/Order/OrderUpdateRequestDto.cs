using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.Dtos.Requests.Order
{
    public class OrderUpdateRequestDto
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
    }
}

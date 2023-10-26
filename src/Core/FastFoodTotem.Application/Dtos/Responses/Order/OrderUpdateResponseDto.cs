using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.Dtos.Responses.Order
{
    public class OrderUpdateResponseDto
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
    }
}

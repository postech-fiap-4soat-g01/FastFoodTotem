using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.Dtos.Responses.Order
{
    public class OrderGetByIdResponseDto
    {
        public OrderGetByIdResponseDto(int id, OrderStatus status, IEnumerable<OrderItemResponseDto> items)
        {
            Id = id;
            Status = status;
            Items = items;
        }

        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public IEnumerable<OrderItemResponseDto> Items { get; set; }
    }
}

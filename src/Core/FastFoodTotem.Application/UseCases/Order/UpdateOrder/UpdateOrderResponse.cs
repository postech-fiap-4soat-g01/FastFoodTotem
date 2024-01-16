using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.UseCases.Order.UpdateOrder;

public sealed record UpdateOrderResponse
{
    public int Id { get; set; }
    public OrderStatus Status { get; set; }
}

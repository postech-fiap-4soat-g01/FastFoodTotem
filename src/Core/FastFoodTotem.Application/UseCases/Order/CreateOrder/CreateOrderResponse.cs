using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.UseCases.Order.CreateOrder;

public sealed record CreateOrderResponse
{
    public int Id { get; set; }
    public string PaymentQrCode { get; set; }
    public OrderStatus Status { get; set; }
    public decimal TotalPrice { get; set; }
}

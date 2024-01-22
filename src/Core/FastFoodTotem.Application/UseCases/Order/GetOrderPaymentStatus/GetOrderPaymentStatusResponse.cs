using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.UseCases.Order.GetOrderPaymentStatus;

public sealed record GetOrderPaymentStatusResponse
{
    public int Id { get; set; }
    public PaymentStatus Status { get; set; }
}

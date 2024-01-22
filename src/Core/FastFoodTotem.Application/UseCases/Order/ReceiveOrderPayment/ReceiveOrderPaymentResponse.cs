using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.UseCases.Order.UpdatePaymentOrder;

public sealed record ReceiveOrderPaymentResponse
{
    public int Id { get; set; }
    public PaymentStatus Status { get; set; }
}


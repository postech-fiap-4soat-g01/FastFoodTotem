using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.UseCases.Order.UpdatePaymentOrder;

public sealed record UpdatePaymentOrderResponse
{
    //public UpdatePaymentOrderResponse(int id, OrderStatus status)
    //{
    //    Id = id;
    //    Status = status.Equals(OrderStatus.AwaitingPayment) ? PaymentStatus.AwaitingPayment : status.Equals(OrderStatus.Canceled) ? PaymentStatus.PaymentDenied : PaymentStatus.PaymentConfirmed;
    //}

    public int Id { get; set; }
    public PaymentStatus Status { get; set; }
}


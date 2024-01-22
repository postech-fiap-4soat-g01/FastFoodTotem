using AutoMapper;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.UseCases.Order.ReceiveOrderPayment;

public class ReceiveOrderPaymentMapper : Profile
{
    public ReceiveOrderPaymentMapper()
    {
        CreateMap<ReceiveOrderPaymentRequest, OrderEntity>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrderId))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => OrderStatus.Received));
        CreateMap<OrderEntity, ReceiveOrderPaymentResponse>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapPaymentStatus(src.Status)));
    }

    private static PaymentStatus MapPaymentStatus(OrderStatus orderStatus)
    {
        return orderStatus.Equals(OrderStatus.AwaitingPayment) ? PaymentStatus.AwaitingPayment :
            orderStatus.Equals(OrderStatus.Canceled) ?
            PaymentStatus.PaymentDenied : PaymentStatus.PaymentConfirmed;
    }
}
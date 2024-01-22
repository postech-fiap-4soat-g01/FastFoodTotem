using AutoMapper;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.UseCases.Order.GetOrderPaymentStatus;

public class GetOrderPaymentStatusMapper : Profile
{
    public GetOrderPaymentStatusMapper()
    {
        CreateMap<OrderEntity, GetOrderPaymentStatusResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => MapPaymentStatus(src.Status)));
    }

    private static PaymentStatus MapPaymentStatus(OrderStatus orderStatus)
    {
        return orderStatus.Equals(OrderStatus.AwaitingPayment) ? PaymentStatus.AwaitingPayment :
            orderStatus.Equals(OrderStatus.Canceled) ?
            PaymentStatus.PaymentDenied : PaymentStatus.PaymentConfirmed;
    }
}
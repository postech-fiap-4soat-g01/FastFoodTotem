using AutoMapper;
using FastFoodTotem.Application.UseCases.Order.GetAllOrders;
using FastFoodTotem.Application.UseCases.Order.UpdateOrder;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodTotem.Application.UseCases.Order.UpdatePaymentOrder;

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
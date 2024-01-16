using FastFoodTotem.Domain.Enums;
using MediatR;

namespace FastFoodTotem.Application.UseCases.Order.UpdateOrder;

public sealed record UpdateOrderRequest(int Id, OrderStatus Status) 
    : IRequest<UpdateOrderResponse>;

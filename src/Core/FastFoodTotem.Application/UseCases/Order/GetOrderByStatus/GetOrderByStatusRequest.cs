using FastFoodTotem.Domain.Enums;
using MediatR;

namespace FastFoodTotem.Application.UseCases.Order.GetOrderByStatus;

public sealed record GetOrderByStatusRequest(OrderStatus Status) : IRequest<GetOrderByStatusResponse>;
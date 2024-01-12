using MediatR;

namespace FastFoodTotem.Application.UseCases.Order.GetAllOrders;

public sealed record GetAllOrdersRequest : IRequest<GetAllOrdersResponse>;

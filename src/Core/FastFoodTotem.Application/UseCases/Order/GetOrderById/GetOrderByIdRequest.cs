using MediatR;

namespace FastFoodTotem.Application.UseCases.Order.GetOrderById;

public sealed record GetOrderByIdRequest(int OrderId) : IRequest<GetOrderByIdResponse>;


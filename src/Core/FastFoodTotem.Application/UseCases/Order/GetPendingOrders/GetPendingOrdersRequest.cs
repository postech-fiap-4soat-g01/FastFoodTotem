using MediatR;

namespace FastFoodTotem.Application.UseCases.Order.GetPendingOrders;

public sealed record class GetPendingOrdersRequest : IRequest<GetPendingOrdersResponse>
{
}

using AutoMapper;
using FastFoodTotem.Application.UseCases.Order.GetOrderByStatus;
using FastFoodTotem.Domain.Contracts.Repositories;
using MediatR;

namespace FastFoodTotem.Application.UseCases.Order.GetPendingOrders;

public class GetPendingOrdersHandler : IRequestHandler<GetPendingOrdersRequest, GetPendingOrdersResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetPendingOrdersHandler(
        IOrderRepository orderRepository,
        IMapper mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task<GetPendingOrdersResponse> Handle(GetPendingOrdersRequest request, CancellationToken cancellationToken)
    {
        var pendingOrders = (await _orderRepository.GetPendingOrders(cancellationToken)).ToList();

        var orders = new List<GetPendingOrdersOrder>();

        pendingOrders.ForEach(orderEntity =>
        {
            var order = _mapper.Map<GetPendingOrdersOrder>(orderEntity);
            orders.Add(order);
        });


        var response = new GetPendingOrdersResponse(orders);

        return response;
    }
}

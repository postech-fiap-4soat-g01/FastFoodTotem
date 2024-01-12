using AutoMapper;
using FastFoodTotem.Domain.Contracts.Repositories;
using MediatR;

namespace FastFoodTotem.Application.UseCases.Order.GetAllOrders;

public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersRequest, GetAllOrdersResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetAllOrdersHandler(
        IMapper mapper,
        IOrderRepository orderRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task<GetAllOrdersResponse> Handle(GetAllOrdersRequest request, CancellationToken cancellationToken)
    {
        var result = (await _orderRepository.GetAllAsync(cancellationToken)).ToList();


        var orders = new List<GetAllOrdersOrder>();
        result.ForEach(orderEntity =>
        {
            var order = _mapper.Map<GetAllOrdersOrder>(orderEntity);
            orders.Add(order);
        });


        var response = new GetAllOrdersResponse(orders);

        return response;
    }
}

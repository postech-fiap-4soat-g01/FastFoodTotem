using AutoMapper;
using FastFoodTotem.Domain.Contracts.Repositories;
using MediatR;

namespace FastFoodTotem.Application.UseCases.Order.GetOrderByStatus;

public class GetOrderByStatusHandler : IRequestHandler<GetOrderByStatusRequest, GetOrderByStatusResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderByStatusHandler(
        IOrderRepository orderRepository, 
        IMapper mapper)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task<GetOrderByStatusResponse> Handle(GetOrderByStatusRequest request, CancellationToken cancellationToken)
    {
        var result = (await _orderRepository.GetOrderByStatus(request.Status, cancellationToken)).ToList();

        var orders = new List<GetOrderByStatusOrder>();
        result.ForEach(orderEntity =>
        {
            var order = _mapper.Map<GetOrderByStatusOrder>(orderEntity);
            orders.Add(order);
        });


        var response = new GetOrderByStatusResponse(orders);

        return response;
    }
}

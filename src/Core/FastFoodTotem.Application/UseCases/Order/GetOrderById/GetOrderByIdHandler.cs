using AutoMapper;
using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Exceptions;
using MediatR;

namespace FastFoodTotem.Application.UseCases.Order.GetOrderById;

public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdRequest, GetOrderByIdResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderByIdHandler(IMapper mapper, IOrderRepository orderRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task<GetOrderByIdResponse> Handle(GetOrderByIdRequest request, CancellationToken cancellationToken)
    {
        var result = await _orderRepository.GetOrderAsync(request.OrderId, cancellationToken);

        if (result == null)
            throw new ObjectNotFoundException();

        var response = _mapper.Map<GetOrderByIdResponse>(result);

        return response;
    }

}

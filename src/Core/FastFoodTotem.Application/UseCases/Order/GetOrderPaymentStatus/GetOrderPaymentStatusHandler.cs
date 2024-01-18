using AutoMapper;
using FastFoodTotem.Application.UseCases.Order.GetOrderById;
using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodTotem.Application.UseCases.Order.GetOrderPaymentStatus;

public class GetOrderPaymentStatusHandler : IRequestHandler<GetOrderPaymentStatusRequest, GetOrderPaymentStatusResponse>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderPaymentStatusHandler(IMapper mapper, IOrderRepository orderRepository)
    {
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
    }

    public async Task<GetOrderPaymentStatusResponse> Handle(GetOrderPaymentStatusRequest request, CancellationToken cancellationToken)
    {
        var result = await _orderRepository.GetOrderAsync(request.OrderId, cancellationToken);

        if (result == null)
            throw new ObjectNotFoundException();

        var response = _mapper.Map<GetOrderPaymentStatusResponse>(result);

        return response;
    }

}

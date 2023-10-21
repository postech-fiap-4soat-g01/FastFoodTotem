using AutoMapper;
using FastFoodTotem.Application.ApplicationServicesInterfaces;
using FastFoodTotem.Application.Dtos.Requests.Order;
using FastFoodTotem.Application.Dtos.Responses;
using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Application.ApplicationServices;

public class OrderApplicationService : IOrderApplicationService
{
    private readonly IMapper _mapper;
    private readonly IOrderService _orderService;

    public OrderApplicationService(IMapper mapper, IOrderService orderService)
    {
        _mapper = mapper;
        _orderService = orderService;
    }

    public async Task<OrderCreateResponseDto> CreateAsync(OrderCreateRequestDto orderCreateRequestDto, CancellationToken cancellationToken)
    {
        var result = await _orderService.CreateAsync(_mapper.Map<OrderEntity>(orderCreateRequestDto), cancellationToken);
        return new OrderCreateResponseDto(result.Id);
    }
}

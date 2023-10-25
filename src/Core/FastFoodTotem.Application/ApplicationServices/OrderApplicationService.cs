using AutoMapper;
using FastFoodTotem.Application.ApplicationServicesInterfaces;
using FastFoodTotem.Application.Dtos.Requests.Order;
using FastFoodTotem.Application.Dtos.Responses;
using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Validations;
using FluentValidation;

namespace FastFoodTotem.Application.ApplicationServices;

public class OrderApplicationService : BaseApplicationService, IOrderApplicationService
{
    private readonly IMapper _mapper;
    private readonly IOrderService _orderService;
    private readonly IValidator<OrderCreateRequestDto> _orderCreateRequestDtoValidator;

    public OrderApplicationService(
        IMapper mapper,
        IOrderService orderService,
        IValidationNotifications validationNotifications,
        IValidator<OrderCreateRequestDto> orderCreateRequestDtoValidator)
        : base(validationNotifications)
    {
        _mapper = mapper;
        _orderService = orderService;
        _orderCreateRequestDtoValidator = orderCreateRequestDtoValidator;
    }

    public async Task<ApiBaseResponse<OrderCreateResponseDto>> CreateAsync(OrderCreateRequestDto orderCreateRequestDto, CancellationToken cancellationToken)
    {
        var response = new ApiBaseResponse<OrderCreateResponseDto>();

        if (!await IsDtoValid(_orderCreateRequestDtoValidator, orderCreateRequestDto))
            return response;

        var result = await _orderService.CreateAsync(_mapper.Map<OrderEntity>(orderCreateRequestDto), cancellationToken);
        response.Data = new OrderCreateResponseDto() { Id = result.Id };

        return response;
    }
}

using AutoMapper;
using FastFoodTotem.Application.ApplicationServicesInterfaces;
using FastFoodTotem.Application.Dtos.Requests.Order;
using FastFoodTotem.Application.Dtos.Responses;
using FastFoodTotem.Application.Dtos.Responses.Order;
using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Enums;
using FastFoodTotem.Domain.Validations;
using FluentValidation;

namespace FastFoodTotem.Application.ApplicationServices;

public class OrderApplicationService : BaseApplicationService, IOrderApplicationService
{
    private readonly IMapper _mapper;
    private readonly IOrderService _orderService;
    private readonly IValidator<OrderCreateRequestDto> _orderCreateRequestDtoValidator;
    private readonly IValidator<OrderUpdateRequestDto> _orderUpdateRequestDtoValidator;

    public OrderApplicationService(
        IMapper mapper,
        IOrderService orderService,
        IValidationNotifications validationNotifications,
        IValidator<OrderCreateRequestDto> orderCreateRequestDtoValidator,
        IValidator<OrderUpdateRequestDto> orderUpdateRequestDtoValidator)
        : base(validationNotifications)
    {
        _mapper = mapper;
        _orderService = orderService;
        _orderCreateRequestDtoValidator = orderCreateRequestDtoValidator;
        _orderUpdateRequestDtoValidator = orderUpdateRequestDtoValidator;
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

    public async Task<ApiBaseResponse<OrderGetByIdResponseDto>> GetByIdAsync(int orderId, CancellationToken cancellationToken)
    {
        var response = new ApiBaseResponse<OrderGetByIdResponseDto>();

        var result = await _orderService.GetById(orderId, cancellationToken);
        response.Data = new OrderGetByIdResponseDto(result.Id,
            result.Status,
            result.OrderedItems.Select(item => new OrderItemGetByIdResponseDto()
            {
                Name = item.Product.Name,
                Price = item.Product.Price,
                ProductId = item.ProductId,
                Quantity = item.Amount
            }));

        return response;
    }

    public async Task<ApiBaseResponse<OrderUpdateResponseDto>> UpdateAsync(OrderUpdateRequestDto orderUpdateRequestDto, CancellationToken cancellationToken)
    {
        var response = new ApiBaseResponse<OrderUpdateResponseDto>();

        if (!Enum.IsDefined(typeof(OrderStatus), orderUpdateRequestDto.Status))
        {
            _validationNotifications.AddError("Status", "Status do pedido inválido.");
            return response;
        }

        if (!await IsDtoValid(_orderUpdateRequestDtoValidator, orderUpdateRequestDto))
            return response;

        await _orderService.UpdateAsync(_mapper.Map<OrderEntity>(orderUpdateRequestDto), cancellationToken);
        response.Data = new OrderUpdateResponseDto() { Id = orderUpdateRequestDto.Id, Status = orderUpdateRequestDto.Status };

        return response;
    }
}

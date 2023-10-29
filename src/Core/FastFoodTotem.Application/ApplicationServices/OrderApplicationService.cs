using AutoMapper;
using FastFoodTotem.Application.ApplicationServicesInterfaces;
using FastFoodTotem.Application.Dtos.Requests.Order;
using FastFoodTotem.Application.Dtos.Responses;
using FastFoodTotem.Application.Dtos.Responses.Order;
using FastFoodTotem.Domain.Contracts.Payments;
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
    private readonly IOrderPayment _orderPayment;

    public OrderApplicationService(
        IMapper mapper,
        IOrderService orderService,
        IValidationNotifications validationNotifications,
        IValidator<OrderCreateRequestDto> orderCreateRequestDtoValidator,
        IValidator<OrderUpdateRequestDto> orderUpdateRequestDtoValidator,
        IOrderPayment orderPayment)
        : base(validationNotifications)
    {
        _mapper = mapper;
        _orderService = orderService;
        _orderCreateRequestDtoValidator = orderCreateRequestDtoValidator;
        _orderUpdateRequestDtoValidator = orderUpdateRequestDtoValidator;
        _orderPayment = orderPayment;
    }

    public async Task<ApiBaseResponse<OrderCreateResponseDto>> CreateAsync(OrderCreateRequestDto orderCreateRequestDto, CancellationToken cancellationToken)
    {
        var response = new ApiBaseResponse<OrderCreateResponseDto>();

        if (!await IsDtoValid(_orderCreateRequestDtoValidator, orderCreateRequestDto))
            return response;

        var result = await _orderService.CreateAsync(_mapper.Map<OrderEntity>(orderCreateRequestDto), cancellationToken);

        response.Data = new OrderCreateResponseDto() 
        { 
            Id = result.Id,
            PaymentQrCode = await _orderPayment.GerarQRCodeParaPagamentoDePedido(result),
            Status = result.Status
        };

        return response;
    }

    public async Task<ApiBaseResponse<OrderGetAllResponseDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var response = new ApiBaseResponse<OrderGetAllResponseDto>();

        var result = await _orderService.GetAllAsync(cancellationToken);
        response.Data = new OrderGetAllResponseDto(result.Select(order => CreateOrderIdResponse(order)));

        return response;
    }

    public async Task<ApiBaseResponse<OrderGetByIdResponseDto>> GetByIdAsync(int orderId, CancellationToken cancellationToken)
    {
        var response = new ApiBaseResponse<OrderGetByIdResponseDto>();

        var result = await _orderService.GetByIdAsync(orderId, cancellationToken);
        response.Data = CreateOrderIdResponse(result);

        return response;
    }

    private static OrderGetByIdResponseDto CreateOrderIdResponse(OrderEntity result)
    => new OrderGetByIdResponseDto(result.Id,
        result.Status,
        result.OrderedItems.Select(item => new OrderItemResponseDto()
        {
            Name = item.Product.Name,
            Price = item.Product.Price,
            ProductId = item.ProductId,
            Amount = item.Amount
        }));

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

    public async Task<ApiBaseResponse<OrderGetAllResponseDto>> GetOrderByStatus(OrderStatus status, CancellationToken cancellationToken)
    {
        var response = new ApiBaseResponse<OrderGetAllResponseDto>();

        if (!Enum.IsDefined(typeof(OrderStatus), status))
        {
            _validationNotifications.AddError("Status", "Status do pedido inválido.");
            return response;
        }

        var result = await _orderService.GetOrderByStatus(status, cancellationToken);
        response.Data = new OrderGetAllResponseDto(result.Select(order => CreateOrderIdResponse(order)));

        return response;
    }
}

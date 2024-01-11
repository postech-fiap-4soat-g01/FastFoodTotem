using FastFoodTotem.Application.Dtos.Requests.Order;
using FastFoodTotem.Application.Dtos.Responses;
using FastFoodTotem.Application.Dtos.Responses.Order;
using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.ApplicationServicesInterfaces
{
    public interface IOrderApplicationService
    {
        Task<ApiBaseResponse<OrderCreateResponseDto>> CreateAsync(OrderCreateRequestDto orderCreateRequestDto, CancellationToken cancellationToken);
        Task<ApiBaseResponse<OrderUpdateResponseDto>> UpdateAsync(OrderUpdateRequestDto orderUpdateRequestDto, CancellationToken cancellationToken);
        Task<ApiBaseResponse<OrderGetByIdResponseDto>> GetByIdAsync(int orderId, CancellationToken cancellationToken);
        Task<ApiBaseResponse<OrderGetAllResponseDto>> GetAllAsync(CancellationToken cancellationToken);
        Task<ApiBaseResponse<OrderGetAllResponseDto>> GetOrderByStatus(OrderStatus status, CancellationToken cancellationToken);
        Task<ApiBaseResponse<OrderGetAllResponseDto>> GetPendingOrders(CancellationToken cancellationToken);
        Task<ApiBaseResponse<OrderPaymentStatusResponseDto>> GetOrderPaymentAsync(int orderId, CancellationToken cancellationToken);
    }
}

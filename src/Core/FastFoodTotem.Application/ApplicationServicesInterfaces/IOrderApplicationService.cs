using FastFoodTotem.Application.Dtos.Requests.Order;
using FastFoodTotem.Application.Dtos.Responses;
using FastFoodTotem.Application.Dtos.Responses.Order;

namespace FastFoodTotem.Application.ApplicationServicesInterfaces
{
    public interface IOrderApplicationService
    {
        Task<ApiBaseResponse<OrderCreateResponseDto>> CreateAsync(OrderCreateRequestDto orderCreateRequestDto, CancellationToken cancellationToken);
        Task<ApiBaseResponse<OrderUpdateResponseDto>> UpdateAsync(OrderUpdateRequestDto orderUpdateRequestDto, CancellationToken cancellationToken);
        Task<ApiBaseResponse<OrderGetByIdResponseDto>> GetByIdAsync(int orderId, CancellationToken cancellationToken);
    }
}

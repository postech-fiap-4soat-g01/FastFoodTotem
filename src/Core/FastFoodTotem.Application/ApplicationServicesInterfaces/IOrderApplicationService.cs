using FastFoodTotem.Application.Dtos.Requests.Order;
using FastFoodTotem.Application.Dtos.Responses;

namespace FastFoodTotem.Application.ApplicationServicesInterfaces
{
    public interface IOrderApplicationService
    {
        Task<ApiBaseResponse<OrderCreateResponseDto>> CreateAsync(OrderCreateRequestDto orderCreateRequestDto, CancellationToken cancellationToken);
    }
}

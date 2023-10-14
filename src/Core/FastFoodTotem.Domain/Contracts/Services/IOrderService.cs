using FastFoodTotem.Application.Dtos.Requests.Order;
using FastFoodTotem.Application.Dtos.Responses;

namespace FastFoodTotem.Domain.Contracts.Services
{
    public interface IOrderService
    {
        public Task<OrderCreateResponseDto> CreateAsync(OrderCreateRequestDto orderCreateRequestDto, CancellationToken cancellationToken);
    }
}

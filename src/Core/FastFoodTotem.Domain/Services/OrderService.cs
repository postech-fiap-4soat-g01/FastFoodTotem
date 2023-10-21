using FastFoodTotem.Application.Dtos.Requests.Order;
using FastFoodTotem.Application.Dtos.Responses;
using FastFoodTotem.Domain.Contracts.Services;

namespace FastFoodTotem.Domain.Services
{
    public class OrderService : IOrderService
    {
        public Task<OrderCreateResponseDto> CreateAsync(OrderCreateRequestDto orderCreateRequestDto, CancellationToken cancellationToken)
        => Task.FromResult(new OrderCreateResponseDto(Guid.NewGuid()));
    }
}

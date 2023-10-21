using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Domain.Contracts.Services
{
    public interface IOrderService
    {
        public Task<OrderEntity> CreateAsync(OrderEntity orderCreateRequestDto, CancellationToken cancellationToken);
    }
}

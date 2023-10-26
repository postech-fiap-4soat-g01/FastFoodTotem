using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Domain.Contracts.Services
{
    public interface IOrderService
    {
        public Task<OrderEntity> CreateAsync(OrderEntity orderEntity, CancellationToken cancellationToken);
        public Task UpdateAsync(OrderEntity orderEntity, CancellationToken cancellationToken);
        public Task<OrderEntity> GetById(int orderId, CancellationToken cancellationToken);
    }
}

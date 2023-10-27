using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Domain.Contracts.Services
{
    public interface IOrderService
    {
        public Task<OrderEntity> CreateAsync(OrderEntity orderEntity, CancellationToken cancellationToken);
        public Task UpdateAsync(OrderEntity orderEntity, CancellationToken cancellationToken);
        public Task<OrderEntity> GetByIdAsync(int orderId, CancellationToken cancellationToken);
        public Task<IEnumerable<OrderEntity>> GetAllAsync(CancellationToken cancellationToken);
    }
}

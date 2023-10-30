using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Domain.Contracts.Services
{
    public interface IOrderService
    {
        public Task<OrderEntity> CreateAsync(OrderEntity orderEntity, CancellationToken cancellationToken);
        public Task UpdateAsync(OrderEntity orderEntity, CancellationToken cancellationToken);
        public Task<OrderEntity> GetByIdAsync(int orderId, CancellationToken cancellationToken);
        public Task<IEnumerable<OrderEntity>> GetAllAsync(CancellationToken cancellationToken);
        Task<IEnumerable<OrderEntity>> GetOrderByStatus(OrderStatus status, CancellationToken cancellationToken);
        Task<IEnumerable<OrderEntity>> GetPendingOrders(CancellationToken cancellationToken);
    }
}

using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Domain.Contracts.Repositories
{
    public interface IOrderRepository
    {
        Task AddOrderAsync(OrderEntity order, CancellationToken cancellationToken);
        Task EditOrderAsync(OrderEntity order, CancellationToken cancellationToken);
        Task<OrderEntity?> GetOrderAsync(int orderId, CancellationToken cancellationToken);
    }
}

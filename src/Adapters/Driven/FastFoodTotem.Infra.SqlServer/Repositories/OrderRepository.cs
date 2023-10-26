using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Infra.SqlServer.Database;

namespace FastFoodTotem.Infra.SqlServer.Repositories
{
    public class OrderRepository : BaseRepository<int, OrderEntity>, IOrderRepository
    {
        public OrderRepository(FastFoodContext fastFoodContext) : base(fastFoodContext)
        {
        }

        public async Task AddOrderAsync(OrderEntity order, CancellationToken cancellationToken)
        {
            await CreateAsync(order);
            await SaveChangesAsync(cancellationToken);
        }

        public async Task EditOrderAsync(OrderEntity order, CancellationToken cancellationToken)
        {
            Update(order);
            await SaveChangesAsync(cancellationToken);
        }

        public async Task<OrderEntity?> GetOrderAsync(int orderId, CancellationToken cancellationToken)
        => await Data.FindAsync(orderId, cancellationToken);
    }
}

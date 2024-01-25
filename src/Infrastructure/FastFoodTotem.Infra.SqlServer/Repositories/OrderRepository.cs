using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Enums;
using FastFoodTotem.Infra.SqlServer.Database;
using Microsoft.EntityFrameworkCore;

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

            order = await Data.Include(x => x.OrderedItems).ThenInclude(x => x.Product).Include(x => x.Customer).FirstAsync(x => x.Id == order.Id);
        }

        public async Task EditOrderAsync(OrderEntity order, CancellationToken cancellationToken)
        {
            Update(order);
            await SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<OrderEntity>> GetAllAsync(CancellationToken cancellationToken)
         => await Data
            .Include(x => x.OrderedItems)
            .ThenInclude(x => x.Product)
            .Include(x => x.Customer)
            .OrderBy(x => x.Status)
            .ToListAsync(cancellationToken);

        public async Task<OrderEntity?> GetOrderAsync(int orderId, CancellationToken cancellationToken)
            => await Data.Include(x => x.OrderedItems).ThenInclude(x => x.Product).Include(x => x.Customer).FirstOrDefaultAsync(x => x.Id == orderId);

        public async Task<IEnumerable<OrderEntity>> GetOrderByStatus(OrderStatus status, CancellationToken cancellationToken)
        {
            return await
                    Data
                    .Include(x => x.OrderedItems)
                    .ThenInclude(x => x.Product)
                    .Include(x => x.Customer)
                    .Where(x => x.Status == status)
                    .ToListAsync();
        }

        public async Task<IEnumerable<OrderEntity>> GetPendingOrders(CancellationToken cancellationToken)
        {
            return await Data
                .Where(x => x.Status == OrderStatus.Received
                         || x.Status == OrderStatus.InPreparation
                         || x.Status == OrderStatus.Ready)
                .OrderByDescending(x => x.Status)
                .ThenBy(x => x.CreationDate)
                .Include(x => x.OrderedItems)
                .ThenInclude(x => x.Product)
                .Include(x => x.Customer)
                .ToListAsync(cancellationToken);

        }
    }
}

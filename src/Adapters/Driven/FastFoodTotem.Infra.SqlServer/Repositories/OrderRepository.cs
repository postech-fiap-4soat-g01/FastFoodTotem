using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Infra.SqlServer.Database;

namespace FastFoodTotem.Infra.SqlServer.Repositories
{
    internal class OrderRepository : BaseRepository<Guid, OrderEntity>, IOrderRepository
    {
        public OrderRepository(FastFoodContext fastFoodContext) : base(fastFoodContext)
        {
        }
    }
}

using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Infra.SqlServer.Database;

namespace FastFoodTotem.Infra.SqlServer.Repositories
{
    internal class ProductRepository : BaseRepository<Guid, ProductEntity>, IProductRepository
    {
        public ProductRepository(FastFoodContext fastFoodContext) : base(fastFoodContext)
        {
        }
    }
}

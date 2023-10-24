using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Infra.SqlServer.Database;

namespace FastFoodTotem.Infra.SqlServer.Repositories
{
    public class ProductRepository : BaseRepository<int, ProductEntity>, IProductRepository
    {
        public ProductRepository(FastFoodContext fastFoodContext) : base(fastFoodContext)
        {
        }
    }
}

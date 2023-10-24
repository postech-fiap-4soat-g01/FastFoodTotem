using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Infra.SqlServer.Database;
using System.Threading;

namespace FastFoodTotem.Infra.SqlServer.Repositories
{
    public class ProductRepository : BaseRepository<int, ProductEntity>, IProductRepository
    {
        public ProductRepository(FastFoodContext fastFoodContext) : base(fastFoodContext)
        {
        }

        public async Task CreateProductAsync(ProductEntity product, CancellationToken cancellationToken)
        {
            await CreateAsync(product);
            await SaveChangesAsync(cancellationToken);
        }
    }
}

using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Enums;
using FastFoodTotem.Infra.SqlServer.Database;

namespace FastFoodTotem.Infra.SqlServer.Repositories
{
    public class ProductRepository : BaseRepository<int, ProductEntity>, IProductRepository
    {
        public ProductRepository(FastFoodContext fastFoodContext) : base(fastFoodContext)
        {
        }

        public async Task CreateProduct(ProductEntity product, CancellationToken cancellationToken)
        {
            await CreateAsync(product);
            await SaveChangesAsync(cancellationToken);
        }

        public async Task EditProduct(ProductEntity product, CancellationToken cancellationToken)
        {
            Update(product);
            await SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteProduct(ProductEntity product, CancellationToken cancellationToken)
        {
            Delete(product);
            await SaveChangesAsync(cancellationToken);
        }

        public async Task<ProductEntity?> GetProduct(int productId, CancellationToken cancellationToken)
        {
            return await Data.FindAsync(productId, cancellationToken);
        }

        public async Task<IEnumerable<ProductEntity>> GetProductsByCategory(CategoryType type, CancellationToken cancellationToken)
        {
            return await FindByConditionAsync(x => x.Type == type, cancellationToken);
        }
    }
}

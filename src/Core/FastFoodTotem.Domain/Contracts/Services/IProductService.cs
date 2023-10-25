using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Domain.Contracts.Services
{
    public interface IProductService
    {
        public Task<ProductEntity> CreateAsync(ProductEntity product, CancellationToken cancellationToken);
        public Task<ProductEntity> EditAsync(ProductEntity product, CancellationToken cancellationToken);
        public Task DeleteAsync(int productId, CancellationToken cancellationToken);
        public Task<IEnumerable<ProductEntity>> GetByCategoryAsync(CategoryType type, CancellationToken cancellationToken);
    }
}

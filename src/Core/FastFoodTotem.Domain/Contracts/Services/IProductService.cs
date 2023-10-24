using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Domain.Contracts.Services
{
    public interface IProductService
    {
        public Task<ProductEntity> CreateAsync(ProductEntity productCreateRequestDto, CancellationToken cancellationToken);
        public Task<ProductEntity> EditAsync(ProductEntity productCreateRequestDto, CancellationToken cancellationToken);
        public Task DeleteAsync(int productId, CancellationToken cancellationToken);
        public Task<IEnumerable<ProductEntity>> GetByCategoryAsync(CancellationToken cancellationToken);
    }
}

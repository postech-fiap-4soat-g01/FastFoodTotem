using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Domain.Services
{
    public class ProductService : IProductService
    {
        public Task<ProductEntity> CreateAsync(ProductEntity productCreateRequestDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid productId, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<ProductEntity> EditAsync(ProductEntity productCreateRequestDto, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductEntity>> GetByCategoryAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

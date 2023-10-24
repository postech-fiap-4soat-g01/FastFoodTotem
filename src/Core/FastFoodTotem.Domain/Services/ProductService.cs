using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        public async Task<ProductEntity> CreateAsync(ProductEntity product, CancellationToken cancellationToken)
        {
            await _productRepository.CreateProductAsync(product, cancellationToken);
            return product;
        }

        public Task DeleteAsync(int productId, CancellationToken cancellationToken)
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

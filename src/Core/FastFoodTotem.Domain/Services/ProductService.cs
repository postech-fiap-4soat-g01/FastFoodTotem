using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Enums;
using FastFoodTotem.Domain.Exceptions;
using FastFoodTotem.Domain.Validations;

namespace FastFoodTotem.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IValidationNotifications _validationNotifications;

        public ProductService(IProductRepository productRepository, IValidationNotifications validationNotifications)
        {
            _productRepository = productRepository;
            _validationNotifications = validationNotifications;
        }

        public async Task<ProductEntity> CreateAsync(ProductEntity product, CancellationToken cancellationToken)
        {
            await _productRepository.CreateProduct(product, cancellationToken);
            return product;
        }

        public async Task<ProductEntity> EditAsync(ProductEntity product, CancellationToken cancellationToken)
        {
            var existentProduct = await _productRepository.GetProduct(product.Id, cancellationToken);

            if (existentProduct == null)
                throw new ObjectNotFoundException();

            existentProduct.Price = product.Price;
            existentProduct.Name = product.Name;
            existentProduct.Type = product.Type;

            await _productRepository.EditProduct(existentProduct, cancellationToken);
            return product;
        }

        public async Task DeleteAsync(int productId, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProduct(productId, cancellationToken);

            if (product == null)
                throw new ObjectNotFoundException();

            await _productRepository.DeleteProduct(product, cancellationToken);
        }

        public async Task<IEnumerable<ProductEntity>> GetByCategoryAsync(CategoryType type, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetProductsByCategory(type, cancellationToken);

            return products;
        }
    }
}

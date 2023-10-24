using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Domain.Contracts.Repositories;

public interface IProductRepository
{
    Task CreateProduct(ProductEntity product, CancellationToken cancellationToken);
    Task DeleteProduct(ProductEntity product, CancellationToken cancellationToken);
    Task EditProduct(ProductEntity product, CancellationToken cancellationToken);
    Task<ProductEntity?> GetProduct(int productId, CancellationToken cancellationToken);
    Task<IEnumerable<ProductEntity>> GetProductsByCategory(CategoryType type, CancellationToken cancellationToken);
}


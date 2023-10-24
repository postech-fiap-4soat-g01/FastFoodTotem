using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Domain.Contracts.Repositories;

public interface IProductRepository
{
    Task CreateProductAsync(ProductEntity product, CancellationToken cancellationToken);
}


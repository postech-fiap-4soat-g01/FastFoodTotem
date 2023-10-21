using FastFoodTotem.Application.Dtos.Requests.Product;
using FastFoodTotem.Application.Dtos.Responses.Product;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Application.ApplicationServicesInterfaces;

public interface IProductApplicationService
{
    public Task<ProductCreateResponseDto> CreateAsync(ProductCreateRequestDto productCreateRequestDto, CancellationToken cancellationToken);
    public Task<ProductEditResponseDto> EditAsync(ProductEditRequestDto productCreateRequestDto, CancellationToken cancellationToken);
    public Task<ProductDeleteResponseDto> DeleteAsync(Guid productId, CancellationToken cancellationToken);
    public Task<ProductGetByCategoryResponseDto> GetByCategoryAsync(Guid categoryId, CancellationToken cancellationToken);
}


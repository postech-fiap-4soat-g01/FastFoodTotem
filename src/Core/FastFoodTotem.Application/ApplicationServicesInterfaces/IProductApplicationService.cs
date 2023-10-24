using FastFoodTotem.Application.Dtos.Requests.Product;
using FastFoodTotem.Application.Dtos.Responses;
using FastFoodTotem.Application.Dtos.Responses.Product;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Application.ApplicationServicesInterfaces;

public interface IProductApplicationService
{
    public Task<ApiBaseResponse<ProductCreateResponseDto>> CreateAsync(ProductCreateRequestDto productCreateRequestDto, CancellationToken cancellationToken);
    public Task<ApiBaseResponse<ProductEditResponseDto>> EditAsync(ProductEditRequestDto productCreateRequestDto, CancellationToken cancellationToken);
    public Task<ApiBaseResponse<ProductDeleteResponseDto>> DeleteAsync(int productId, CancellationToken cancellationToken);
    public Task<ApiBaseResponse<ProductGetByCategoryResponseDto>> GetByCategoryAsync(int categoryId, CancellationToken cancellationToken);
}


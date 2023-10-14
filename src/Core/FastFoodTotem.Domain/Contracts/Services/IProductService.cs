using FastFoodTotem.Application.Dtos.Requests.Product;
using FastFoodTotem.Application.Dtos.Responses.Product;

namespace FastFoodTotem.Domain.Contracts.Services
{
    public interface IProductService
    {
        public Task<ProductCreateResponseDto> CreateAsync(ProductCreateRequestDto productCreateRequestDto, CancellationToken cancellationToken);
        public Task<ProductEditResponseDto> EditAsync(ProductEditRequestDto productCreateRequestDto, CancellationToken cancellationToken);
        public Task<ProductDeleteResponseDto> DeleteAsync(ProductDeleteRequestDto productCreateRequestDto, CancellationToken cancellationToken);
        public Task<ProductGetByCategoryResponseDto> GetByCategoryAsync(ProductGetByCategoryRequestDto productGetByCategoryRequestDto, CancellationToken cancellationToken);
    }
}

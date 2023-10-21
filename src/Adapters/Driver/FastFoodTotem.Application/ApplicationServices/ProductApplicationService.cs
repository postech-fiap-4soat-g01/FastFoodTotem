using AutoMapper;
using FastFoodTotem.Application.ApplicationServicesInterfaces;
using FastFoodTotem.Application.Dtos.Requests.Product;
using FastFoodTotem.Application.Dtos.Responses.Product;
using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Application.ApplicationServices;

public class ProductApplicationService : IProductApplicationService
{
    private readonly IMapper _mapper;
    private readonly IProductService _productService;

    public ProductApplicationService(IProductService productService, IMapper mapper)
    {
        _productService = productService;
        _mapper = mapper;
    }

    public async Task<ProductCreateResponseDto> CreateAsync(ProductCreateRequestDto productCreateRequestDto, CancellationToken cancellationToken)
    {
        var productCreated = await _productService.CreateAsync(_mapper.Map<ProductEntity>(productCreateRequestDto), cancellationToken);
        return _mapper.Map<ProductCreateResponseDto>(productCreated);
    }

    public async Task<ProductDeleteResponseDto> DeleteAsync(Guid productId, CancellationToken cancellationToken)
    {
        await _productService.DeleteAsync(productId, cancellationToken);
        return new ProductDeleteResponseDto();
    }

    public async Task<ProductEditResponseDto> EditAsync(ProductEditRequestDto productEditRequestDto, CancellationToken cancellationToken)
    {
        var productEdited = await _productService.CreateAsync(_mapper.Map<ProductEntity>(productEditRequestDto), cancellationToken);
        return _mapper.Map<ProductEditResponseDto>(productEdited);
    }

    public async Task<ProductGetByCategoryResponseDto> GetByCategoryAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        await _productService.GetByCategoryAsync(cancellationToken);
        return new ProductGetByCategoryResponseDto();
    }
}

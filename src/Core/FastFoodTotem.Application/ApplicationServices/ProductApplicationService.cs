using AutoMapper;
using Azure;
using FastFoodTotem.Application.ApplicationServicesInterfaces;
using FastFoodTotem.Application.Dtos.Requests.Product;
using FastFoodTotem.Application.Dtos.Responses.Product;
using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Validations;
using FluentValidation;

namespace FastFoodTotem.Application.ApplicationServices;

public class ProductApplicationService : BaseApplicationService, IProductApplicationService
{
    private readonly IMapper _mapper;
    private readonly IProductService _productService;
    private readonly IValidator<ProductCreateRequestDto> _productCreateRequestDtoValidator;
    private readonly IValidator<ProductEditRequestDto> _productEditRequestDtoValidator;

    public ProductApplicationService(
        IProductService productService,
        IMapper mapper,
        IValidator<ProductCreateRequestDto> productCreateRequestDtoValidator,
        IValidator<ProductEditRequestDto> productEditRequestDtoValidator,
        IValidationNotifications validationNotifications)
        : base(validationNotifications)
    {
        _productService = productService;
        _mapper = mapper;
        _productCreateRequestDtoValidator = productCreateRequestDtoValidator;
        _productEditRequestDtoValidator = productEditRequestDtoValidator;
    }

    public async Task<ProductCreateResponseDto> CreateAsync(ProductCreateRequestDto productCreateRequestDto, CancellationToken cancellationToken)
    {
        var response = new ProductCreateResponseDto();

        if (!await IsDtoValid(_productCreateRequestDtoValidator, productCreateRequestDto))
            return response;

        var productCreated = await _productService.CreateAsync(_mapper.Map<ProductEntity>(productCreateRequestDto), cancellationToken);
        return _mapper.Map<ProductCreateResponseDto>(productCreated);
    }

    public async Task<ProductDeleteResponseDto> DeleteAsync(Guid productId, CancellationToken cancellationToken)
    {
        var response = new ProductDeleteResponseDto();

        if (productId == (Guid.Empty))
        {
            _validationNotifications.AddError("ProductId", "O id deve estar especificado");
            return response;
        }

        await _productService.DeleteAsync(productId, cancellationToken);
        return response;
    }

    public async Task<ProductEditResponseDto> EditAsync(ProductEditRequestDto productEditRequestDto, CancellationToken cancellationToken)
    {
        var response = new ProductEditResponseDto();

        if (!await IsDtoValid(_productEditRequestDtoValidator, productEditRequestDto))
            return response;

        var productEdited = await _productService.CreateAsync(_mapper.Map<ProductEntity>(productEditRequestDto), cancellationToken);
        return _mapper.Map<ProductEditResponseDto>(productEdited);
    }

    public async Task<ProductGetByCategoryResponseDto> GetByCategoryAsync(Guid categoryId, CancellationToken cancellationToken)
    {
        var response = new ProductGetByCategoryResponseDto();

        if (categoryId == (Guid.Empty))
        {
            _validationNotifications.AddError("CategoryId", "O id deve estar especificado");
            return response;
        }

        await _productService.GetByCategoryAsync(cancellationToken);
        return new ProductGetByCategoryResponseDto();
    }
}

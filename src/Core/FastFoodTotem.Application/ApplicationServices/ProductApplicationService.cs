using AutoMapper;
using Azure;
using FastFoodTotem.Application.ApplicationServicesInterfaces;
using FastFoodTotem.Application.Dtos.Requests.Product;
using FastFoodTotem.Application.Dtos.Responses;
using FastFoodTotem.Application.Dtos.Responses.Product;
using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Enums;
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

    public async Task<ApiBaseResponse<ProductCreateResponseDto>> CreateAsync(ProductCreateRequestDto productCreateRequestDto, CancellationToken cancellationToken)
    {
        var response = new ApiBaseResponse<ProductCreateResponseDto>();
        if (!await IsDtoValid(_productCreateRequestDtoValidator, productCreateRequestDto))
            return response;

        var productCreated = await _productService.CreateAsync(_mapper.Map<ProductEntity>(productCreateRequestDto), cancellationToken);
        response.Data = _mapper.Map<ProductCreateResponseDto>(productCreated);

        return response;
    }

    public async Task<ApiBaseResponse<ProductDeleteResponseDto>> DeleteAsync(int productId, CancellationToken cancellationToken)
    {
        var response = new ApiBaseResponse<ProductDeleteResponseDto>();

        if (productId <= 0)
        {
            _validationNotifications.AddError("ProductId", "O id deve estar especificado");
            return response;
        }

        await _productService.DeleteAsync(productId, cancellationToken);
        return response;
    }

    public async Task<ApiBaseResponse<ProductEditResponseDto>> EditAsync(ProductEditRequestDto productEditRequestDto, CancellationToken cancellationToken)
    {
        var response = new ApiBaseResponse<ProductEditResponseDto>();

        if (!await IsDtoValid(_productEditRequestDtoValidator, productEditRequestDto))
            return response;

        var productEdited = await _productService.EditAsync(_mapper.Map<ProductEntity>(productEditRequestDto), cancellationToken);
        response.Data = _mapper.Map<ProductEditResponseDto>(productEdited);

        return response;
    }

    public async Task<ApiBaseResponse<ProductGetByCategoryResponseDto>> GetByCategoryAsync(CategoryType type, CancellationToken cancellationToken)
    {
        var response = new ApiBaseResponse<ProductGetByCategoryResponseDto>();

        var products = await _productService.GetByCategoryAsync(type, cancellationToken);
        response.Data = new ProductGetByCategoryResponseDto();
        response.Data.Products = _mapper.Map<List<ProductData>>(products);
        return response;
    }
}

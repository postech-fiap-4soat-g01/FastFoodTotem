using AutoMapper;
using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Entities;
using MediatR;

namespace FastFoodTotem.Application.UseCases.Product.CreateProduct;

public class CreateProductHandler : IRequestHandler<CreateProductRequest, CreateProductResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateProductHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
    }

    public async Task<CreateProductResponse> Handle(CreateProductRequest request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<ProductEntity>(request);
        await _productRepository.CreateProduct(product, cancellationToken);

        return _mapper.Map<CreateProductResponse>(product);
    }
}

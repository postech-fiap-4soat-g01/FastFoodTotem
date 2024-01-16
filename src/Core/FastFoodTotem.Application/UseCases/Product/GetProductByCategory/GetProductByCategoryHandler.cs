using AutoMapper;
using FastFoodTotem.Domain.Contracts.Repositories;
using MediatR;

namespace FastFoodTotem.Application.UseCases.Product.GetProductByCategory;

public class GetProductByCategoryHandler : IRequestHandler<GetProductByCategoryRequest, GetProductByCategoryResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public GetProductByCategoryHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
    }

    public async Task<GetProductByCategoryResponse> Handle(GetProductByCategoryRequest request, CancellationToken cancellationToken)
    {
        var products = await _productRepository.GetProductsByCategory(request.Type, cancellationToken);

        var productsResponse = _mapper.Map<IEnumerable<GetProductByCategoryProductData>>(products);

        return new GetProductByCategoryResponse() { Products = productsResponse };
    }
}

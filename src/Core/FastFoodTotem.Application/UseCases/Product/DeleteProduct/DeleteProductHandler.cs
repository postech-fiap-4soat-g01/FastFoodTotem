using AutoMapper;
using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Exceptions;
using MediatR;

namespace FastFoodTotem.Application.UseCases.Product.DeleteProduct;

public class DeleteProductHandler : IRequestHandler<DeleteProductRequest, DeleteProductResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public DeleteProductHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(_mapper));
    }

    public async Task<DeleteProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetProduct(request.ProductId, cancellationToken);

        if (product == null)
            throw new ObjectNotFoundException();

        await _productRepository.DeleteProduct(product, cancellationToken);

        return new DeleteProductResponse();
    }
}

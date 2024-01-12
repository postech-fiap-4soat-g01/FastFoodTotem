using MediatR;

namespace FastFoodTotem.Application.UseCases.Product.DeleteProduct;

public sealed record DeleteProductRequest : IRequest<DeleteProductResponse>
{
    public int ProductId {get; set;}

    public DeleteProductRequest(int productId)
    {
        ProductId = productId;
    }
}

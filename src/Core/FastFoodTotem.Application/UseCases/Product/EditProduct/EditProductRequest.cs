using FastFoodTotem.Domain.Enums;
using MediatR;

namespace FastFoodTotem.Application.UseCases.Product.EditProduct;

public sealed record EditProductRequest(
    int Id,
    string Name,
    CategoryType Type,
    decimal Price,
    string Description,
    string ProductImageUrl) : IRequest<EditProductResponse>;

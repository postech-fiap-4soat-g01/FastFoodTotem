using FastFoodTotem.Domain.Enums;
using MediatR;

namespace FastFoodTotem.Application.UseCases.Product.CreateProduct;

public sealed record CreateProductRequest
    (
    string Name,
    CategoryType Type,
    decimal Price,
    string Description,
    string ProductImageUrl) : IRequest<CreateProductResponse>;

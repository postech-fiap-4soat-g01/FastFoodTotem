using FastFoodTotem.Domain.Enums;
using MediatR;

namespace FastFoodTotem.Application.UseCases.Product.GetProductByCategory;

public sealed record GetProductByCategoryRequest : IRequest<GetProductByCategoryResponse>
{
    public CategoryType Type { get; set; }

    public GetProductByCategoryRequest(CategoryType type)
    {
        Type = type;
    }
}

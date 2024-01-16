using FastFoodTotem.Domain.Enums;

namespace FastFoodTotem.Application.UseCases.Product.GetProductByCategory;

public sealed record GetProductByCategoryResponse
{
    public IEnumerable<GetProductByCategoryProductData> Products { get; set; }
}

public sealed record GetProductByCategoryProductData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public CategoryType Type { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
    public string ProductImageUrl { get; set; }
}

using AutoMapper;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Application.UseCases.Product.GetProductByCategory;

public class GetProductByCategoryMapper : Profile
{
    public GetProductByCategoryMapper()
    {
        CreateMap<ProductEntity, GetProductByCategoryProductData>();
    }
}

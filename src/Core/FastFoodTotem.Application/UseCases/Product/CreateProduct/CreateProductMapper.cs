using AutoMapper;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Application.UseCases.Product.CreateProduct;

public class CreateProductMapper : Profile
{
    public CreateProductMapper()
    {
        CreateMap<CreateProductRequest, ProductEntity>();
        CreateMap<ProductEntity, CreateProductResponse>();
    }
}

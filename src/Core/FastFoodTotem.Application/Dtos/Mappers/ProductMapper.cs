using AutoMapper;
using FastFoodTotem.Application.Dtos.Requests.Product;
using FastFoodTotem.Application.Dtos.Responses.Product;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Application.Dtos.Mappers;

public class ProductMapper : Profile
{
    public ProductMapper()
    {
        CreateMap<ProductCreateRequestDto, ProductEntity>();
        CreateMap<ProductEntity, ProductCreateResponseDto>();
        CreateMap<ProductEditRequestDto, ProductEntity>();
        CreateMap<ProductEntity, ProductEditResponseDto>();
    }
}


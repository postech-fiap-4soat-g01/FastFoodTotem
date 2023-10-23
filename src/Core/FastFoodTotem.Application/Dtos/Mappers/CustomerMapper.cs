using AutoMapper;
using FastFoodTotem.Application.Dtos.Requests.Customer;
using FastFoodTotem.Application.Dtos.Responses.Customer;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Application.Dtos.Mappers;

public class CustomerMapper : Profile
{
    public CustomerMapper()
    {
        CreateMap<CustomerCreateRequestDto, CustomerEntity>();
        CreateMap<CustomerEntity, CustomerGetResponseData>();
    }
}


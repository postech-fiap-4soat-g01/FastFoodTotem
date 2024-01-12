using AutoMapper;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Application.UseCases.Customer.CreateCustomer;

public class CreateCustomerMapper : Profile
{
    public CreateCustomerMapper()
    {
        CreateMap<CreateCustomerRequest, CustomerEntity>();
    }
}

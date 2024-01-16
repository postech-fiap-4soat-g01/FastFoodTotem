using AutoMapper;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Application.UseCases.Customer.GetCustomerByCpf;

public class GetCustomerByCpfMapper: Profile
{
    public GetCustomerByCpfMapper()
    {
        CreateMap<CustomerEntity, GetCustomerByCpfResponse>();
    }
}

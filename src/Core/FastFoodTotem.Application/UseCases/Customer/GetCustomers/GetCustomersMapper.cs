using AutoMapper;
using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Application.UseCases.Customer.GetCustomers
{
    internal class GetCustomersMapper : Profile
    {
        public GetCustomersMapper()
        {
            CreateMap<CustomerEntity, Customers>();
        }
    }
}

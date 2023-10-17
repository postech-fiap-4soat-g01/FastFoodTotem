﻿using FastFoodTotem.Application.Dtos.Requests.Customer;
using FastFoodTotem.Application.Dtos.Responses.Customer;

namespace FastFoodTotem.Domain.Contracts.Repositories
{
    public interface ICustomerRepository
    {
        Task<CustomerCreateResponseDto> AddCustomer(CustomerCreateRequestDto customer, CancellationToken cancellationToken);
        Task<CustomerGetByCPFResponseDto> GetCustomerByCPF(string cpf, CancellationToken cancellationToken);
        Task<IEnumerable<CustomerGetResponseDto>> GetCustomers(CancellationToken cancellationToken);
    }
}

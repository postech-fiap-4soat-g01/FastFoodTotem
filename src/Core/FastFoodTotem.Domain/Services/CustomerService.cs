using FastFoodTotem.Application.Dtos.Requests.Customer;
using FastFoodTotem.Application.Dtos.Responses.Customer;
using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Exceptions;

namespace FastFoodTotem.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService (ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task AddCustomerAsync(CustomerCreateRequestDto customer, CancellationToken cancellationToken)
        {
            var existingCustomer = await _customerRepository.GetCustomerByCPFAsync(customer.Identification, cancellationToken);

            if (existingCustomer != null)
                throw new DomainException("Customer already exists");

            await _customerRepository.AddCustomerAsync(new(customer), cancellationToken);
        }

        public async Task<CustomerGetByCPFResponseDto> GetCustomerByCPFAsync(string cpf, CancellationToken cancellationToken)
        {
            var customerByCpf = await _customerRepository.GetCustomerByCPFAsync(cpf, cancellationToken) 
                ?? throw new DomainException("No customer found for this CPF");
            var customerByCpfDto = new CustomerGetByCPFResponseDto(customerByCpf.Id, customerByCpf.Name, customerByCpf.Email);
            return customerByCpfDto;
        }

        public async Task<IEnumerable<CustomerGetResponseDto>> GetCustomersAsync(CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetCustomersAsync(cancellationToken);

            var customerGetResponseDto = customers.Select(customer => new CustomerGetResponseDto(
                customer.Id,
                customer.Name,
                customer.Email,
                customer.Identification
                ));

            return customerGetResponseDto;
        }
    }
}

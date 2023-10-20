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
            var existingCustomer = await _customerRepository.GetCustomerByCPFAsync(customer.CustomerIdentification, cancellationToken);

            if (existingCustomer != null)
                throw new DomainException("Customer already exists");

            await _customerRepository.AddCustomerAsync(new(customer), cancellationToken);
        }

        public async Task<CustomerGetByCPFResponseDto> GetCustomerByCPFAsync(string cpf, CancellationToken cancellationToken)
        {
            var customerByCpf = await _customerRepository.GetCustomerByCPFAsync(cpf, cancellationToken);

            if(customerByCpf != null)
            {
                var customerByCpfDto = new CustomerGetByCPFResponseDto(customerByCpf.Id, customerByCpf.CustomerName, customerByCpf.CustomerEmail);

                return customerByCpfDto;
            }

            throw new DomainException("No customer found for this CPF");
        }

        public async Task<IEnumerable<CustomerGetResponseDto>> GetCustomersAsync(CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetCustomersAsync(cancellationToken);

            var customerGetResponseDto = customers.Select(customer => new CustomerGetResponseDto(
                customer.Id,
                customer.CustomerName,
                customer.CustomerEmail,
                customer.CustomerIdentification
                ));

            return customerGetResponseDto;
        }
    }
}

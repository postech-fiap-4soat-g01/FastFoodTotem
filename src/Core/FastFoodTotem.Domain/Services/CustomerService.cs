using FastFoodTotem.Application.Dtos.Requests.Customer;
using FastFoodTotem.Application.Dtos.Responses.Customer;
using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Contracts.Services;

namespace FastFoodTotem.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService (ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        //TODO: Customer exists validation
        public async Task<CustomerCreateResponseDto> AddCustomer(CustomerCreateRequestDto customer, CancellationToken cancellationToken)
            => await _customerRepository.AddCustomer(customer, cancellationToken);

        //TODO: Null validation
        public async Task<CustomerGetByCPFResponseDto> GetCustomerByCPF(string cpf, CancellationToken cancellationToken)
            => await _customerRepository.GetCustomerByCPF(cpf, cancellationToken);

        public async Task<IEnumerable<CustomerGetResponseDto>> GetCustomers(CancellationToken cancellationToken)
            => await _customerRepository.GetCustomers(cancellationToken);
    }
}

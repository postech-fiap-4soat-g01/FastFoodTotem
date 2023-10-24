using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Contracts.Services;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Domain.Exceptions;
using FastFoodTotem.Domain.Validations;

namespace FastFoodTotem.Domain.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IValidationNotifications _validationNotifications;

        public CustomerService(ICustomerRepository customerRepository, IValidationNotifications validationNotifications)
        {
            _customerRepository = customerRepository;
            _validationNotifications = validationNotifications;
        }

        public async Task AddCustomerAsync(CustomerEntity customer, CancellationToken cancellationToken)
        {
            var existingCustomer = await _customerRepository.GetCustomerByCPFAsync(customer.Identification, cancellationToken);

            if (existingCustomer != null)
                _validationNotifications.AddError("Identification", "Já existe um usuário cadastrado com esse CPF.");
            else
            {
                customer.Identification.Replace(".", string.Empty).Replace("-", string.Empty);
                await _customerRepository.AddCustomerAsync(customer, cancellationToken);
            }

        }

        public async Task<CustomerEntity> GetCustomerByCPFAsync(string cpf, CancellationToken cancellationToken)
        {
            var customerByCpf = await _customerRepository.GetCustomerByCPFAsync(cpf, cancellationToken)
                ?? throw new ObjectNotFoundException("No customer found for this CPF");

            return customerByCpf;
        }

        public async Task<IEnumerable<CustomerEntity>> GetCustomersAsync(CancellationToken cancellationToken)
        {
            var customers = await _customerRepository.GetCustomersAsync(cancellationToken);
            return customers;
        }
    }
}

using FastFoodTotem.Application.Dtos.Requests.Customer;
using FastFoodTotem.Application.Dtos.Responses.Customer;
using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodTotem.Infra.SqlServer.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        //Mock test
        private List<CustomerEntity> customerEntities = new()
        {
            new CustomerEntity(Guid.NewGuid(), "Marcello Corassin", "marcellocorassin@email.com", "43918762050"),
            new CustomerEntity(Guid.NewGuid(), "Fernando", "fernando@email.com", "23667528060"),
            new CustomerEntity(Guid.NewGuid(), "Thais Tozzato", "thaistozzato@email.com", "87905346030"),
            new CustomerEntity(Guid.NewGuid(), "Thalys Cesar", "thalyscesar@email.com", "64982498032"),
            new CustomerEntity(Guid.NewGuid(), "Vinicius", "vinicius@email.com", "10905819047")
        };

        public async Task<CustomerCreateResponseDto> AddCustomer(CustomerCreateRequestDto customer, CancellationToken cancellationToken)
        {
            Guid customerId = Guid.NewGuid();
            CustomerEntity customerEntity = new(customerId, customer.CustomerName, customer.CustomerEmail, customer.CustomerIdentification);
            customerEntities.Add(customerEntity);
            return new CustomerCreateResponseDto(customerId);
        }

        public async Task<CustomerGetByCPFResponseDto> GetCustomerByCPF(string cpf, CancellationToken cancellationToken)
        {
            CustomerEntity customerEntity = customerEntities.First(c => c.CustomerIdentification.Equals(cpf));

            return customerEntity == null
                ? throw new Exception("Nenhum cliente localizado com CPF.")
                : new CustomerGetByCPFResponseDto(customerEntity.Id, customerEntity.CustomerName, customerEntity.CustomerEmail);
        }

        public async Task<IEnumerable<CustomerGetResponseDto>> GetCustomers(CancellationToken cancellationToken)
            => customerEntities.Select(c => new CustomerGetResponseDto(c.Id, c.CustomerName, c.CustomerEmail, c.CustomerIdentification));
    }
}

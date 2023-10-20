using FastFoodTotem.Application.Dtos.Requests.Customer;
using FastFoodTotem.Application.Dtos.Responses.Customer;
using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Infra.SqlServer.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastFoodTotem.Infra.SqlServer.Repositories
{
    internal class CustomerRepository : BaseRepository<Guid, CustomerEntity>, ICustomerRepository
    {
        public CustomerRepository(FastFoodContext fastFoodContext) : base(fastFoodContext)
        {
        }

        public async Task AddCustomerAsync(CustomerEntity customer, CancellationToken cancellationToken)
        {
            await CreateAsync(customer, cancellationToken);
            await SaveChangesAsync(cancellationToken);
        }

        public async Task<CustomerEntity> GetCustomerByCPFAsync(string cpf, CancellationToken cancellationToken)
            => await Data.FirstOrDefaultAsync(c => c.CustomerIdentification == cpf, cancellationToken);

        public async Task<IEnumerable<CustomerEntity>> GetCustomersAsync(CancellationToken cancellationToken) => await FindAllAsync(cancellationToken);
    }
}

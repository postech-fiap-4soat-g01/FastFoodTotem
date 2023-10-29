using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Domain.Contracts.Repositories
{
    public interface ICustomerRepository
    {
        Task AddCustomerAsync(CustomerEntity customer, CancellationToken cancellationToken);
        Task<CustomerEntity?> GetCustomerByCPFAsync(string cpf, CancellationToken cancellationToken);
        Task<CustomerEntity?> GetCustomerByIdAsync(int id, CancellationToken cancellationToken);
        Task<IEnumerable<CustomerEntity>> GetCustomersAsync(CancellationToken cancellationToken);
    }
}

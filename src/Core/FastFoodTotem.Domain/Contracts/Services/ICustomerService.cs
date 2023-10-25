using FastFoodTotem.Domain.Entities;

namespace FastFoodTotem.Domain.Contracts.Services
{
    public interface ICustomerService
    {
        Task AddCustomerAsync(CustomerEntity customer, CancellationToken cancellationToken);
        Task<CustomerEntity> GetCustomerByCPFAsync(string cpf, CancellationToken cancellationToken);
        Task<IEnumerable<CustomerEntity>> GetCustomersAsync(CancellationToken cancellationToken);
    }
}

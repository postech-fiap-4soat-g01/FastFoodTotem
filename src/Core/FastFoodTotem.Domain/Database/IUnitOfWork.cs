using FastFoodTotem.Domain.Contracts.Repositories;

namespace FastFoodTotem.Domain.Database
{
    public interface IUnitOfWork
    {
        ICategoryRepository Categories { get; }
    }
}

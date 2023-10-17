using FastFoodTotem.Domain.Contracts.Repositories;

namespace FastFoodTotem.Domain.Database
{
    public interface IUnitOfWork
    {
        ICategoryEntityRepository Categories { get; }
    }
}

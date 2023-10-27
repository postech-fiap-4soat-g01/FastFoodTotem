using System.Linq.Expressions;

namespace FastFoodTotem.Domain.Contracts.Repositories.Base
{
    public interface IBaseRepository<TId, TEntity> where TEntity : class
    {
        TEntity? FindById(TId id);
        Task<IEnumerable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);
        Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken cancellationToken);
        Task CreateAsync(TEntity entity, CancellationToken cancellationToken);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<bool> HasAnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

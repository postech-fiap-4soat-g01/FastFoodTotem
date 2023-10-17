using System.Linq.Expressions;

namespace FastFoodTotem.Domain.Contracts.Repositories.Base
{
    public interface IBaseRepository<TId, TEntity> where TEntity : class
    {
        Task<TEntity> FindByIdAsync(TId id);
        Task<IEnumerable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> FindAllAsync();
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        void DeleteAsync(TEntity entity);
        Task<bool> HasAnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<int> SaveChangesAsync();
    }
}

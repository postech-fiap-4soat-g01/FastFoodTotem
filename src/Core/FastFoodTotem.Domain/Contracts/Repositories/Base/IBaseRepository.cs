using System.Linq.Expressions;

namespace FastFoodTotem.Domain.Contracts.Repositories.Base
{
    public interface IBaseRepository<TId, TEntity> where TEntity : class
    {
        TEntity FindById(TId id);
        Task<IEnumerable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression);
        Task<IEnumerable<TEntity>> FindAllAsync();
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<bool> HasAnyAsync(Expression<Func<TEntity, bool>> expression);
        Task<int> SaveChangesAsync();
    }
}

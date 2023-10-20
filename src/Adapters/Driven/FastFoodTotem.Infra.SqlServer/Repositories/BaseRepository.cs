using FastFoodTotem.Domain.Contracts.Repositories.Base;
using FastFoodTotem.Infra.SqlServer.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FastFoodTotem.Infra.SqlServer.Repositories
{
    internal abstract class BaseRepository<TId, TEntity> : IBaseRepository<TId, TEntity> where TEntity : class
    {
        protected DbSet<TEntity> Data { get; }
        protected FastFoodContext _context;

        public BaseRepository(FastFoodContext fastFoodContext)
        {
            this._context = fastFoodContext;
            this.Data = _context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await Data.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            Data.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync()
        {
            return Data.ToList();
        }

        public async Task<IEnumerable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression)
        {
            return Data.Where(expression).ToList();
        }

        public TEntity FindById(TId id)
        {
            return Data.Find(id);
        }

        public Task<bool> HasAnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            return Data.AnyAsync(expression);
        }

        public void Update(TEntity entity)
        {
            Data.Update(entity);
        }

        public Task<int> SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }
    }
}

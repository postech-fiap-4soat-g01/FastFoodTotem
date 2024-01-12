using FastFoodTotem.Domain.Contracts.Repositories.Base;
using FastFoodTotem.Infra.SqlServer.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FastFoodTotem.Infra.SqlServer.Repositories
{
    public abstract class BaseRepository<TId, TEntity> : IBaseRepository<TId, TEntity> where TEntity : class
    {
        protected DbSet<TEntity> Data { get; }
        protected FastFoodContext _context;

        public BaseRepository(FastFoodContext fastFoodContext)
        {
            this._context = fastFoodContext;
            this.Data = _context.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Data.AddAsync(entity, cancellationToken);
        }

        public void Delete(TEntity entity)
        {
            Data.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(CancellationToken cancellationToken = default)
        {
            return await Data.ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken = default)
        {
            return await Data.Where(expression).ToListAsync(cancellationToken);
        }

        public TEntity? FindById(TId id)
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

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}

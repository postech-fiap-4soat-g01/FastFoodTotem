using FastFoodTotem.Domain.Contracts.Repositories.Base;
using FastFoodTotem.Infra.SqlServer.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FastFoodTotem.Infra.SqlServer.Repositories
{
    internal abstract class BaseRepository<TId, TEntity> : IBaseRepository<TId,TEntity> where TEntity: class
    {
        protected DbSet<TEntity> Data { get; }
        protected FastFoodContext _context;

        public async Task CreateAsync(TEntity entity)
        {
            await Data.AddAsync(entity);
        }

        public void DeleteAsync(TEntity entity)
        {
            Data.Remove(entity);
        }

        public Task<IEnumerable<TEntity>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindByIdAsync(TId id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> HasAnyAsync(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveChangesAsync()
        {
           return _context.SaveChangesAsync();
        }
    }
}

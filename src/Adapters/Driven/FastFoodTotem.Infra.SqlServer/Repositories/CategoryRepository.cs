using FastFoodTotem.Domain.Contracts.Repositories;
using FastFoodTotem.Domain.Entities;
using FastFoodTotem.Infra.SqlServer.Database;

namespace FastFoodTotem.Infra.SqlServer.Repositories
{
    public class CategoryRepository : BaseRepository<int, CategoryEntity>, ICategoryRepository
    {
        public CategoryRepository(FastFoodContext fastFoodContext) : base(fastFoodContext)
        {
        }
    }
}

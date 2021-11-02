using Ardalis.Specification.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Abstract
{
    public class EfGenericRepository<TEntity> : RepositoryBase<TEntity>  
        where TEntity : class
    {
        public EfGenericRepository(CarRentalDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}

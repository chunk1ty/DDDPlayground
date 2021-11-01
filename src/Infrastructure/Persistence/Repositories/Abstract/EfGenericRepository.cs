using Ardalis.Specification.EntityFrameworkCore;
using SharedKernel;

namespace Infrastructure.Persistence.Repositories.Abstract
{
    public class EfGenericRepository<TEntity> : RepositoryBase<TEntity>  
        where TEntity : class, IAggregateRoot
    {
        public EfGenericRepository(CarRentalDbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories.Abstract
{
    public class EfGenericRepository<TEntity> : RepositoryBase<TEntity>
        where TEntity : class
    {
        private readonly CarRentalDbContext _carRentalDbContext;

        public EfGenericRepository(CarRentalDbContext dbContext)
            : base(dbContext)
        {
            _carRentalDbContext = dbContext;
        }

        public override async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _carRentalDbContext.Set<TEntity>().Add(entity);

            await _carRentalDbContext.SaveEntitiesAsync(cancellationToken);

            return entity;
        }

        public override async Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _carRentalDbContext.Entry(entity).State = EntityState.Modified;

            await _carRentalDbContext.SaveEntitiesAsync(cancellationToken);
        }

        public override async Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            _carRentalDbContext.Set<TEntity>().Remove(entity);

            await _carRentalDbContext.SaveEntitiesAsync(cancellationToken);
        }
    }
}

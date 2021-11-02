using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.DealerAggregate;
using Domain.Aggregates.DealerAggregate.Contracts;
using Infrastructure.Persistence.Repositories.Abstract;

namespace Infrastructure.Persistence.Repositories
{
    public class DealerRepository : IDealerRepository
    {
        private readonly EfGenericRepository<Dealer> _dealerEfGenericRepository;

        public DealerRepository(EfGenericRepository<Dealer> dealerEfGenericRepository)
        {
            _dealerEfGenericRepository = dealerEfGenericRepository;
        }

        public Task<Dealer> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return _dealerEfGenericRepository.GetByIdAsync(id, cancellationToken);
        }
    }
}

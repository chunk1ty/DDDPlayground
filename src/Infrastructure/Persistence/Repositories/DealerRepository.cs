using Domain.Aggregates.DealerAggregate;
using Domain.Aggregates.DealerAggregate.Contracts;

namespace Infrastructure.Persistence.Repositories
{
    public class DealerRepository : IDealerRepository
    {
        public Dealer GetById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.CarAdAggregate;
using Domain.Aggregates.CarAdAggregate.Contracts;

namespace Infrastructure.Persistence.Repositories
{
    public class CarAdRepository : ICarAdRepository
    {
        public Task<Category> GetBySpec<Spec>(Spec specification, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}

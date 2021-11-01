using Ardalis.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Aggregates.CarAdAggregate.Contracts
{
    public interface ICarAdRepository
    {
        Task<Category> GetBySpec<Spec>(Spec specification, CancellationToken cancellationToken = default);
    }
}

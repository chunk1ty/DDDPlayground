using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace Domain.Aggregates.CarAdAggregate.Contracts
{
    public interface ICarAdRepository
    {
        Task<Category> GetBySpec<Spec>(Spec specification, CancellationToken cancellationToken = default)
            where Spec : ISingleResultSpecification, ISpecification<Category>;

        Task<CarAd> Add(CarAd carAd, CancellationToken cancellationToken = default);
    }
}

using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace Domain.Aggregates.CarAdAggregate.Contracts
{
    public interface ICarAdWriteRepository
    {
        Task<CarAd> Add(CarAd carAd, CancellationToken cancellationToken = default);

        Task Delete(CarAd carAd, CancellationToken cancellationToken = default);

        Task Update(CarAd carAd, CancellationToken cancellationToken = default);
    }
}

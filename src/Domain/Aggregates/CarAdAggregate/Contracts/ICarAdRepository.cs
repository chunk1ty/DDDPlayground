using System.Threading;
using System.Threading.Tasks;

namespace Domain.Aggregates.CarAdAggregate.Contracts
{
    public interface ICarAdRepository
    {
        Task<Category> GetId(int id, CancellationToken cancellationToken = default);

        Task<CarAd> Add(CarAd carAd, CancellationToken cancellationToken = default);

        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}

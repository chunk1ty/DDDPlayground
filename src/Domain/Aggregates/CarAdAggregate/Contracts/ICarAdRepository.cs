using System.Threading;
using System.Threading.Tasks;

namespace Domain.Aggregates.CarAdAggregate.Contracts
{
    public interface ICarAdRepository
    {
        Task<Category> GetCategoryById(int id, CancellationToken cancellationToken = default);

        Task<CarAd> GetCarAdById(int id, CancellationToken cancellationToken = default);

        Task<CarAd> Add(CarAd carAd, CancellationToken cancellationToken = default);

        Task Delete(CarAd carAd, CancellationToken cancellationToken = default);

        Task Update(CarAd carAd, CancellationToken cancellationToken = default);
    }
}

using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;

namespace Domain.Aggregates.CarAdAggregate.Contracts
{
    public interface ICarAdRepository
    {
        Task<Category> GetCategoryById(int id, CancellationToken cancellationToken = default);

        Task<CarAd> GetCarAdById(int id, CancellationToken cancellationToken = default);

        Task<CarAd> GetCarAdBySpec<Spec>(Spec specification, CancellationToken cancellationToken = default)
            where Spec : ISpecification<CarAd>, ISingleResultSpecification;

        Task<TResult[]> GetCarAdListAsync<TCarAd,TResult>(ISpecification<TCarAd, TResult> specification, CancellationToken cancellationToken = default);

        Task<TResult[]> GetCarAdCategoriesListAsync<TCarAd, TResult>(ISpecification<TCarAd, TResult> specification, CancellationToken cancellationToken = default);

        Task<CarAd> Add(CarAd carAd, CancellationToken cancellationToken = default);

        Task Delete(CarAd carAd, CancellationToken cancellationToken = default);

        Task Update(CarAd carAd, CancellationToken cancellationToken = default);
    }
}

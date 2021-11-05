using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;
using Domain.Aggregates.CarAdAggregate;
using Domain.Aggregates.CarAdAggregate.Contracts;
using Infrastructure.Persistence.Repositories.Abstract;

namespace Infrastructure.Persistence.Repositories
{
    public class CarAdReadRepository : ICarAdReadRepository
    {
        private readonly EfGenericRepository<Category> _categoryRepository;
        private readonly EfGenericRepository<CarAd> _carAdRepository;

        public CarAdReadRepository(EfGenericRepository<Category> categoryRepository, EfGenericRepository<CarAd> carAdRepository)
        {
            _categoryRepository = categoryRepository;
            _carAdRepository = carAdRepository;
        }

        public Task<Category> GetCategoryById(int id, CancellationToken cancellationToken = default)
        {
            return _categoryRepository.GetByIdAsync(id, cancellationToken);
        }

        public Task<CarAd> GetCarAdById(int id, CancellationToken cancellationToken = default)
        {
            return _carAdRepository.GetByIdAsync(id, cancellationToken);
        }

        public Task<CarAd> GetCarAdBySpec<Spec>(Spec specification, CancellationToken cancellationToken = default)
            where Spec : ISpecification<CarAd>, ISingleResultSpecification
        {
            return _carAdRepository.GetBySpecAsync(specification, cancellationToken);
        }

        public Task<TResult[]> GetCarAdListAsync<T, TResult>(ISpecification<T, TResult> specification, CancellationToken cancellationToken = default)
        {
            return _carAdRepository.ArrayAsync<TResult>((ISpecification<CarAd, TResult>) specification, cancellationToken);
        }

        public Task<TResult[]> GetCarAdCategoriesListAsync<TCarAd, TResult>(ISpecification<TCarAd, TResult> specification, CancellationToken cancellationToken = default)
        {
            return _categoryRepository.ArrayAsync<TResult>((ISpecification<Category, TResult>)specification, cancellationToken);
        }
    }
}

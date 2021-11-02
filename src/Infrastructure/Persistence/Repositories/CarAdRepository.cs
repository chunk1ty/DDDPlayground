using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Ardalis.Specification;
using Domain.Aggregates.CarAdAggregate;
using Domain.Aggregates.CarAdAggregate.Contracts;
using Domain.Aggregates.CarAdAggregate.Specifications;
using Infrastructure.Persistence.Repositories.Abstract;

namespace Infrastructure.Persistence.Repositories
{
    public class CarAdRepository : ICarAdRepository
    {
        private readonly EfGenericRepository<Category> _categoryRepository;
        private readonly EfGenericRepository<CarAd> _carAdRepository;

        public CarAdRepository(EfGenericRepository<Category> categoryRepository, EfGenericRepository<CarAd> carAdRepository)
        {
            _categoryRepository = categoryRepository;
            _carAdRepository = carAdRepository;
        }

        public Task<Category> GetId(int id, CancellationToken cancellationToken = default)
        {
            return _categoryRepository.GetByIdAsync(id, cancellationToken);
        }

        public Task<CarAd> Add(CarAd carAd, CancellationToken cancellationToken = default)
        {
            return _carAdRepository.AddAsync(carAd, cancellationToken);
        }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            CarAd carAd = await _carAdRepository.GetByIdAsync(id, cancellationToken);

            Guard.Against.Null(carAd, nameof(carAd));

            await _carAdRepository.DeleteAsync(carAd, cancellationToken);

            return true;
        }
    }
}

using System.Threading;
using System.Threading.Tasks;
using Ardalis.GuardClauses;
using Domain.Aggregates.CarAdAggregate;
using Domain.Aggregates.CarAdAggregate.Contracts;
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

        public Task<Category> GetCategoryById(int id, CancellationToken cancellationToken = default)
        {
            return _categoryRepository.GetByIdAsync(id, cancellationToken);
        }

        public Task<CarAd> GetCarAdById(int id, CancellationToken cancellationToken = default)
        {
            return _carAdRepository.GetByIdAsync(id, cancellationToken);
        }

        public Task<CarAd> Add(CarAd carAd, CancellationToken cancellationToken = default)
        {
            return _carAdRepository.AddAsync(carAd, cancellationToken);
        }

        public async Task Delete(CarAd carAd, CancellationToken cancellationToken = default)
        {
            await _carAdRepository.DeleteAsync(carAd, cancellationToken);
        }

        public async Task Update(CarAd carAd, CancellationToken cancellationToken = default)
        {
             await _carAdRepository.UpdateAsync(carAd, cancellationToken);
        }
    }
}

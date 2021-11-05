using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.CarAdAggregate;
using Domain.Aggregates.CarAdAggregate.Contracts;
using Infrastructure.Persistence.Repositories.Abstract;

namespace Infrastructure.Persistence.Repositories
{
    public class CarAdWriteRepository : ICarAdWriteRepository
    {
        private readonly EfGenericRepository<CarAd> _carAdRepository;

        public CarAdWriteRepository(EfGenericRepository<CarAd> carAdRepository)
        {
            _carAdRepository = carAdRepository;
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

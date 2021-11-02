using System.Threading;
using System.Threading.Tasks;
using Ardalis.Specification;
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

        public Task<Category> GetBySpec<Spec>(Spec specification, CancellationToken cancellationToken = default)
            where Spec : ISingleResultSpecification, ISpecification<Category>
        {
            return _categoryRepository.GetBySpecAsync(specification, cancellationToken);
        }

        public Task<CarAd> Add(CarAd carAd, CancellationToken cancellationToken = default)
        {
            return _carAdRepository.AddAsync(carAd, cancellationToken);
        }
    }
}

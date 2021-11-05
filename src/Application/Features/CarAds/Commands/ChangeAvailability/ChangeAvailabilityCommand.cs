using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.CarAdAggregate;
using Domain.Aggregates.CarAdAggregate.Contracts;
using MediatR;

namespace Application.Features.CarAds.Commands.ChangeAvailability
{
    public class ChangeAvailabilityCommand : IRequest<bool>
    {
        public int CarAdId { get; set; }
    }

    public class ChangeAvailabilityHandler : IRequestHandler<ChangeAvailabilityCommand, bool>
    {
        private readonly ICarAdWriteRepository _carAdWriteRepository;
        private readonly ICarAdReadRepository _carAdReadRepository;

        public ChangeAvailabilityHandler(ICarAdReadRepository carAdReadRepository, ICarAdWriteRepository carAdWriteRepository)
        {
            _carAdReadRepository = carAdReadRepository;
            _carAdWriteRepository = carAdWriteRepository;
        }

        public async Task<bool> Handle(ChangeAvailabilityCommand request, CancellationToken cancellationToken)
        {
            CarAd carAd = await _carAdReadRepository.GetCarAdById(request.CarAdId, cancellationToken);

            carAd.ChangeAvailability();

            await _carAdWriteRepository.Update(carAd, cancellationToken);

            return true;
        }
    }
}

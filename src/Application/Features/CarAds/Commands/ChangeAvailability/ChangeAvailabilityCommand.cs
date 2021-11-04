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
        private readonly ICarAdRepository _carAdRepository;

        public ChangeAvailabilityHandler(ICarAdRepository carAdRepository)
        {
            _carAdRepository = carAdRepository;
        }

        public async Task<bool> Handle(ChangeAvailabilityCommand request, CancellationToken cancellationToken)
        {
            CarAd carAd = await _carAdRepository.GetCarAdById(request.CarAdId, cancellationToken);

            carAd.ChangeAvailability();

            await _carAdRepository.Update(carAd, cancellationToken);

            return true;
        }
    }
}

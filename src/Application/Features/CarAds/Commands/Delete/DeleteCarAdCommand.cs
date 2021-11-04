using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.CarAdAggregate;
using Domain.Aggregates.CarAdAggregate.Contracts;

namespace Application.Features.CarAds.Commands.Delete
{
    public class DeleteCarAdCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class DeleteCarAdCommandHandler : IRequestHandler<DeleteCarAdCommand, bool>
    {
        private readonly ICarAdRepository _carAdRepository;

        public DeleteCarAdCommandHandler(ICarAdRepository carAdRepository)
        {
            _carAdRepository = carAdRepository;
        }

        public async Task<bool> Handle(DeleteCarAdCommand request, CancellationToken cancellationToken)
        {
            CarAd carAd = await _carAdRepository.GetCarAdById(request.Id, cancellationToken);

            carAd.Delete();

            await _carAdRepository.Delete(carAd, cancellationToken);

            return true;
        }
    }
}

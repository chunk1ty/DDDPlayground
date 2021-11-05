using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.CarAdAggregate;
using Domain.Aggregates.CarAdAggregate.Contracts;
using Domain.Aggregates.DealerAggregate;
using Domain.Aggregates.DealerAggregate.Contracts;
using MediatR;

namespace Application.Features.CarAds.Commands.Create
{
    public class CreateCarAdCommand : IRequest<CreateCarAdResponse>
    {
        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public int CategoryId { get; set; }

        public string ImageUrl { get; set; }

        public decimal PricePerDay { get; set; }

        public bool HasClimateControl { get; set; }

        public int NumberOfSeats { get; set; }

        public TransmissionType TransmissionType { get; set; }

        public int DealerId { get; set; }
    }

    public class CreateCarAdCommandHandler : IRequestHandler<CreateCarAdCommand, CreateCarAdResponse>
    {
        private readonly ICarAdWriteRepository _carAdWriteRepository;
        private readonly IDealerRepository _dealerRepository;
        private readonly ICarAdReadRepository _carAdReadRepository;

        public CreateCarAdCommandHandler(ICarAdWriteRepository carAdWriteRepository, IDealerRepository dealerRepository, ICarAdReadRepository carAdReadRepository)
        {
            _carAdWriteRepository = carAdWriteRepository;
            _dealerRepository = dealerRepository;
            _carAdReadRepository = carAdReadRepository;
        }

        public async Task<CreateCarAdResponse> Handle(CreateCarAdCommand request, CancellationToken cancellationToken)
        {
            Category category = await _carAdReadRepository.GetCategoryById(request.CategoryId, cancellationToken);
            var manufacturer = new Manufacturer(request.ManufacturerName);
            var options = new Options(request.HasClimateControl, request.NumberOfSeats, request.TransmissionType);

            var carAd = new CarAd(manufacturer,
                                  request.Model,
                                  category,
                                  request.ImageUrl,
                                  request.PricePerDay,
                                  options);

            Dealer dealer = await _dealerRepository.GetByIdAsync(request.DealerId, cancellationToken);
            dealer.AddCarAd(carAd);
            
            await _carAdWriteRepository.Add(carAd, cancellationToken);

            return new CreateCarAdResponse(carAd.Id);
        }
    }
}

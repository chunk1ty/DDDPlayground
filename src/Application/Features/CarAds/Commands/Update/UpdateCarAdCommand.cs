using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.CarAdAggregate;
using Domain.Aggregates.CarAdAggregate.Contracts;
using MediatR;

namespace Application.Features.CarAds.Commands.Update
{
    public class UpdateCarAdCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public int CategoryId { get; set; }

        public string ImageUrl { get; set; }

        public decimal PricePerDay { get; set; }

        public bool HasClimateControl { get; set; }

        public int NumberOfSeats { get; set; }

        public TransmissionType TransmissionType { get; set; }
    }

    public class UpdateCarAdHandler : IRequestHandler<UpdateCarAdCommand, bool>
    {
        private readonly ICarAdRepository _carAdRepository;

        public UpdateCarAdHandler(ICarAdRepository carAdRepository)
        {
            _carAdRepository = carAdRepository;
        }

        public async Task<bool> Handle(UpdateCarAdCommand request, CancellationToken cancellationToken)
        {
            CarAd carAd = await _carAdRepository.GetCarAdById(request.Id, cancellationToken);
            Category carAdCategory = await _carAdRepository.GetCategoryById(request.CategoryId, cancellationToken);
            // add more validations if required ...

            carAd.UpdateCarAd(new Manufacturer(request.ManufacturerName),
                              request.Model,
                              carAdCategory,
                              request.ImageUrl,
                              request.PricePerDay,
                              new Options(request.HasClimateControl, 
                                          request.NumberOfSeats, 
                                          request.TransmissionType));

            await _carAdRepository.Update(carAd, cancellationToken);

            return true;
        }
    }
}

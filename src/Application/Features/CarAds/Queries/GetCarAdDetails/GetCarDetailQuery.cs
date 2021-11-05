using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.CarAdAggregate;
using Domain.Aggregates.CarAdAggregate.Contracts;
using Domain.Aggregates.DealerAggregate;
using Domain.Aggregates.DealerAggregate.Contracts;
using MediatR;

namespace Application.Features.CarAds.Queries.GetCarAdDetails
{
    public class GetCarDetailQuery : IRequest<CarAdDetailResponse>
    {
        public int Id { get; set; }

        public int DealerId { get; set; }
    }

    public class GetCarDetailQueryHandler : IRequestHandler<GetCarDetailQuery, CarAdDetailResponse>
    {
        private readonly ICarAdReadRepository _carAdReadRepository;
        private readonly IDealerRepository _dealerRepository;

        public GetCarDetailQueryHandler(ICarAdReadRepository carAdReadRepository, IDealerRepository dealerRepository)
        {
            _carAdReadRepository = carAdReadRepository;
            _dealerRepository = dealerRepository;
        }

        public async Task<CarAdDetailResponse> Handle(GetCarDetailQuery request, CancellationToken cancellationToken)
        {
            CarAd carAd = await _carAdReadRepository.GetCarAdBySpec(new CarAdDetailSpec(request.Id), cancellationToken);
            Dealer dealer = await _dealerRepository.GetByIdAsync(request.DealerId, cancellationToken);

            return new CarAdDetailResponse(carAd.Id,
                                           carAd.Manufacturer.Name,
                                           carAd.Model,
                                           carAd.ImageUrl,
                                           carAd.Category.Name,
                                           carAd.PricePerDay,
                                           carAd.Options.HasClimateControl,
                                           carAd.Options.NumberOfSeats,
                                           carAd.Options.TransmissionType.ToString(),
                                           new DealerDetailResponse(dealer.Id, 
                                                                    dealer.Name,
                                                                    dealer.PhoneNumber));
        }                          
    }
}

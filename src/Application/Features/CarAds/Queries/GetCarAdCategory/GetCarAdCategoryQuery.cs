using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.CarAdAggregate.Contracts;
using MediatR;

namespace Application.Features.CarAds.Queries.GetCarAdCategory
{
    public class GetCarAdCategoryQuery : IRequest<GetCarAdCategoryResponse[]>
    {
    }

    public class GetCarAdCategoryQueryHandler : IRequestHandler<GetCarAdCategoryQuery, GetCarAdCategoryResponse[]>
    {
        private readonly ICarAdRepository _carAdRepository;

        public GetCarAdCategoryQueryHandler(ICarAdRepository carAdRepository)
        {
            _carAdRepository = carAdRepository;
        }

        public Task<GetCarAdCategoryResponse[]> Handle(GetCarAdCategoryQuery request, CancellationToken cancellationToken)
        {
            return _carAdRepository.GetCarAdListAsync(new CarAdCategoriesSpec(), cancellationToken);
        }
    }
}

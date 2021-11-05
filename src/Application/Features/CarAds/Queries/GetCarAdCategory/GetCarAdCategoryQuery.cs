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
        private readonly ICarAdReadRepository _carAdReadRepository;

        public GetCarAdCategoryQueryHandler(ICarAdReadRepository carAdReadRepository)
        {
            _carAdReadRepository = carAdReadRepository;
        }

        public Task<GetCarAdCategoryResponse[]> Handle(GetCarAdCategoryQuery request, CancellationToken cancellationToken)
        {
            return _carAdReadRepository.GetCarAdCategoriesListAsync(new CarAdCategoriesSpec(), cancellationToken);
        }
    }
}

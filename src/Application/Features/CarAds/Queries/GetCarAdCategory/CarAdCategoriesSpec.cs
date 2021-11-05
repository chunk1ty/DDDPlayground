using Ardalis.Specification;
using Domain.Aggregates.CarAdAggregate;

namespace Application.Features.CarAds.Queries.GetCarAdCategory
{
    public class CarAdCategoriesSpec : Specification<Category, GetCarAdCategoryResponse>
    {
        public CarAdCategoriesSpec()
        {
            Query.Select(x => new GetCarAdCategoryResponse(x.Id, x.Name, x.Description));
        }
    }
}

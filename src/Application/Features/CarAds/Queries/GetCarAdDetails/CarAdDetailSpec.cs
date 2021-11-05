using Ardalis.Specification;
using Domain.Aggregates.CarAdAggregate;

namespace Application.Features.CarAds.Queries.GetCarAdDetails
{
    public class CarAdDetailSpec : Specification<CarAd>, ISingleResultSpecification
    {
        public CarAdDetailSpec(int id)
        {
            Query.Where(c => c.Id == id)
                 .Include(c => c.Category)
                 .Include(c => c.Manufacturer);
        }
    }
}

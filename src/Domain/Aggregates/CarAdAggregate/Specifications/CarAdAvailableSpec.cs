using Ardalis.Specification;

namespace Domain.Aggregates.CarAdAggregate.Specifications
{
    public class CarAdAvailableSpec : Specification<CarAd>
    {
        public CarAdAvailableSpec()
        {
            Query.Where(c => c.IsAvailable);
        }
    }
}

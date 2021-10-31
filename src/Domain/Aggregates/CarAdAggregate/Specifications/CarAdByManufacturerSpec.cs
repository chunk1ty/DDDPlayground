using Ardalis.Specification;

namespace Domain.Aggregates.CarAdAggregate.Specifications
{
    public class CarAdByManufacturerSpec : Specification<CarAd>
    {
        public CarAdByManufacturerSpec(string manufacturer)
        {
            Query.Where(c => c.Manufacturer.Name.ToLower().Contains(manufacturer.ToLower()))
                 .Include(c => c.Manufacturer);
        }
    }
}

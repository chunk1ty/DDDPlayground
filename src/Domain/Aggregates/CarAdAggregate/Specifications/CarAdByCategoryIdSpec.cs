using Ardalis.Specification;

namespace Domain.Aggregates.CarAdAggregate.Specifications
{
    public class CarAdByCategoryIdSpec : Specification<CarAd>
    {
        public CarAdByCategoryIdSpec(int categoryId)
        {
            Query.Where(c => c.Category.Id == categoryId)
                 .Include(c => c.Category);
        }
    }
}

using Ardalis.Specification;

namespace Domain.Aggregates.DealerAggregate.Specifications
{
    public class DealerByIdSpec : Specification<Dealer>, ISingleResultSpecification
    {
        public DealerByIdSpec(int id)
        {
            Query.Where(d => d.Id == id);
        }
    }
}

using Ardalis.Specification;

namespace Domain.Aggregates.CarAdAggregate.Specifications
{
    public class CategoryByIdSpec : Specification<Category>
    {
        public CategoryByIdSpec(int id)
        {
            Query.Where(c => c.Id == id);
        }
    }
}

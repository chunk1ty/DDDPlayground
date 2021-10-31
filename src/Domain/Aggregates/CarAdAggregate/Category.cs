using Ardalis.GuardClauses;
using SharedKernel;

namespace Domain.Aggregates.CarAdAggregate
{
    public class Category : Entity<int>
    {
        public Category(string name, string description)
        {
            Name = Guard.Against.StringLength(name, nameof(name), 2, 20);
            Description = Guard.Against.StringLength(description, nameof(description), 20, 1000);
        }

        public string Name { get; }

        public string Description { get; }
    }
}

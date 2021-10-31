using Ardalis.GuardClauses;
using SharedKernel;

namespace Domain.Aggregates.CarAdAggregate
{
    public class Manufacturer : Entity<int>
    {
        public Manufacturer(string name)
        {
            Name = Guard.Against.StringLength(name, nameof(name), 2, 20);
        }

        public string Name { get; }
    }
}

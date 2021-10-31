using Ardalis.GuardClauses;
using SharedKernel;

namespace Domain.Aggregates.CarAdAggregate
{
    public class Options : ValueObject
    {
        public Options(bool hasClimateControl, int numberOfSeats, TransmissionType transmissionType)
        {
            HasClimateControl = hasClimateControl;
            NumberOfSeats = Guard.Against.OutOfRange(numberOfSeats, nameof(numberOfSeats), 2, 50);
            TransmissionType = transmissionType;
        }

        public bool HasClimateControl { get; }

        public int NumberOfSeats { get; }

        public TransmissionType TransmissionType { get; }
    }
}

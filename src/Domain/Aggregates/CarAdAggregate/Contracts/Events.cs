using MediatR;

namespace Domain.Aggregates.CarAdAggregate.Contracts
{
    public record CarAdCreatedDomainEvent(CarAd CarAd) : INotification;

    public record CarAdUpdatedDomainEvent(CarAd CarAd) : INotification;

    public record CarAdUpdatedAvailabilityDomainEvent(CarAd CarAd) : INotification;
}

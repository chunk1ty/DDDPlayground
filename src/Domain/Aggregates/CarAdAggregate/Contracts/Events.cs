using MediatR;

namespace Domain.Aggregates.CarAdAggregate.Contracts
{
    public record CarAdCreatedDomainEvent(CarAd CarAd) : INotification;

    public record CarAdUpdatedDomainEvent(CarAd CarAd) : INotification;

    public record CarAdDeletedDomainEvent(CarAd CarAd) : INotification;

    public record CarAdAvailabilityChangedDomainEvent(CarAd CarAd) : INotification;
}

using MediatR;

namespace Domain.Aggregates.DealerAggregate.Contracts
{
    public record DealerCreatedDomainEvent(Dealer Dealer) : INotification;

    public record DealerUpdatedDomainEvent(Dealer Dealer) : INotification;
}

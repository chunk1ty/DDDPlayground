using Domain.Aggregates.CarAdAggregate.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Application.Features.CarAds.EventHandlers
{
    public class CarAdAvailabilityChangedHandler : INotificationHandler<CarAdAvailabilityChangedDomainEvent>
    {
        private readonly ILogger<CarAdAvailabilityChangedHandler> _logger;

        public CarAdAvailabilityChangedHandler(ILogger<CarAdAvailabilityChangedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CarAdAvailabilityChangedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Car ad availability changed!");

            return Task.CompletedTask;
        }
    }
}

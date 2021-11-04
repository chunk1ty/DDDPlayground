using System.Threading;
using System.Threading.Tasks;
using Domain.Aggregates.CarAdAggregate.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Features.CarAds.EventHandlers
{
    public sealed class CarAdCreatedHandler : INotificationHandler<CarAdCreatedDomainEvent>
    {
        private readonly ILogger<CarAdCreatedHandler> _logger;

        public CarAdCreatedHandler(ILogger<CarAdCreatedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CarAdCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Car ad created!");

            return Task.CompletedTask;
        }
    }
}

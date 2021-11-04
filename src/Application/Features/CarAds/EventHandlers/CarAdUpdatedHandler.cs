using Domain.Aggregates.CarAdAggregate.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Application.Features.CarAds.EventHandlers
{
    public class CarAdUpdatedHandler : INotificationHandler<CarAdUpdatedDomainEvent>
    {
        private readonly ILogger<CarAdDeletedHandler> _logger;

        public CarAdUpdatedHandler(ILogger<CarAdDeletedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CarAdUpdatedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Car ad updated!");

            return Task.CompletedTask;
        }
    }
}

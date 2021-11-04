using Domain.Aggregates.CarAdAggregate.Contracts;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CarAds.EventHandlers
{
    public class CarAdDeletedHandler : INotificationHandler<CarAdDeletedDomainEvent>
    {
        private readonly ILogger<CarAdDeletedHandler> _logger;

        public CarAdDeletedHandler(ILogger<CarAdDeletedHandler> logger)
        {
            _logger = logger;
        }

        public Task Handle(CarAdDeletedDomainEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Car ad deleted!");

            return Task.CompletedTask;
        }
    }
}

using Infrastructure.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Application.Features.CarAds.Commands.ChangeAvailability;

namespace IntegrationTests.Application.Features.CarAds
{
    [TestFixture]
    public class ChangeAvailabilityTest : BaseDatabaseFixture
    {
        [Test]
        public async Task Handle_WithCorrectCommand_ShouldChangeCarAdAvailability()
        {
            // Arrange
            IServiceScope scope = CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            // Act
            var command = new ChangeAvailabilityCommand
            {
                CarAdId = 10
            };

            var response = await mediator.Send(command);

            // Assert
            response.Should().Be(true);

            using (var db = scope.ServiceProvider.GetRequiredService<CarRentalDbContext>())
            {
                var carAd = await db.CarAds.SingleOrDefaultAsync(c => c.Id == command.CarAdId);

                carAd.IsAvailable.Should().BeFalse();
            }
        }
    }
}

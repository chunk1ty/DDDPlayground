using System.Threading.Tasks;
using Application.Features.CarAds.Commands.ChangeAvailability;
using FluentAssertions;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace IntegrationTests.Application.Features.CarAds.Commands
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
                CarAdId = 11
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

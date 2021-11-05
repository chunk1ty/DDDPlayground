using System.Threading.Tasks;
using Application.Features.CarAds.Commands.Delete;
using FluentAssertions;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace IntegrationTests.Application.Features.CarAds.Commands
{
    [TestFixture]
    public class DeleteCarAdTest : BaseDatabaseFixture
    {
        [Test]
        public async Task Handle_WithCorrectCommand_ShouldCreateCarAd()
        {
            // Arrange
            IServiceScope scope = CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            // Act
            var command = new DeleteCarAdCommand()
            {
                Id = 10
            };

            var response = await mediator.Send(command);

            // Assert
            response.Should().Be(true);

            using (var db = scope.ServiceProvider.GetRequiredService<CarRentalDbContext>())
            {
                var carAd = await db.CarAds.SingleOrDefaultAsync(c => c.Id == command.Id);

                carAd.Should().BeNull();
            }
        }
    }
}

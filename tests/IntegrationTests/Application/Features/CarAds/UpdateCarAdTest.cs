using Application.Features.CarAds.Commands.Create;
using Domain.Aggregates.CarAdAggregate;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Application.Features.CarAds.Commands.Update;

namespace IntegrationTests.Application.Features.CarAds
{
    [TestFixture]
    public class UpdateCarAdTest : BaseDatabaseFixture
    {
        [Test]
        public async Task Handle_WithCorrectCommand_ShouldUpdateCarAd()
        {
            // Arrange
            IServiceScope scope = CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            // Act
            // Category and Dealer should be seeded in advanced 
            var command = new UpdateCarAdCommand()
            {
                Id = 11,
                Model = "CX-5",
                CategoryId = 1,
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/a/a2/2010_Volkswagen_Passat_Highline_TDi_140_2.0_Front.jpg",
                PricePerDay = 25,
                HasClimateControl = true,
                NumberOfSeats = 5,
                TransmissionType = TransmissionType.Manual,
                ManufacturerName = "Mazda"
            };

            var response = await mediator.Send(command);

            // Assert
            using (var db = scope.ServiceProvider.GetRequiredService<CarRentalDbContext>())
            {
                var carAd = await db.CarAds.SingleOrDefaultAsync(c => c.Id == command.Id);

                carAd.Model.Should().Be("CX-5");
                carAd.Manufacturer.Name.Should().Be("Mazda");
                carAd.Category.Id.Should().Be(1);
                carAd.PricePerDay.Should().Be(25);
                carAd.Options.HasClimateControl.Should().Be(true);
                carAd.Options.NumberOfSeats.Should().Be(5);
                carAd.Options.TransmissionType.Should().Be(TransmissionType.Manual);
            }
        }
    }
}

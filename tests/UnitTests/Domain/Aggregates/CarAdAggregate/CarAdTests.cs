using Domain.Aggregates.CarAdAggregate;
using FluentAssertions;
using Xunit;

namespace UnitTests.Domain.Aggregates.CarAdAggregate
{
    public class CarAdTests
    {
        [Fact]
        public void ChangeAvailabilityShouldMutateIsAvailable()
        {
            // Arrange

            var carAd = new CarAd(new Manufacturer("Volkswagen"), 
                "Passat",
                new Category("Economy", "Economy cars are extremely comfortable for urban and non-urban condition because of its sizes and maneuverability as well as the best rental prices. We offer huge choice of economy cars available for rent at affordable prices. If our offices are not convenient for you, we will deliver a car directly to you address. Economy cars for rent are from the leading world manufacturers as: Toyota, Renault, Ford, Nissan and others. If you need economy car for rent in Bulgaria, you will find the best offers below. Choose the best economy car hire for your holiday!"),
                "https://upload.wikimedia.org/wikipedia/commons/a/a2/2010_Volkswagen_Passat_Highline_TDi_140_2.0_Front.jpg",
                42,
                new Options(true, 5, TransmissionType.Automatic)
            );

            // Act
            carAd.ChangeAvailability();

            // Assert
            carAd.IsAvailable.Should().BeFalse();
        }
    }
}

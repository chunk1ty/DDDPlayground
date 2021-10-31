using Domain.Aggregates.CarAdAggregate;
using FluentAssertions;
using Xunit;

namespace UnitTests.SharedKernel
{
    public class ValueObjectTests
    {
        [Fact]
        public void ValueObjectsWithEqualPropertiesShouldBeEqual()
        {
            // Arrange
            var first = new Options(true, 2, TransmissionType.Automatic);
            var second = new Options(true, 2, TransmissionType.Automatic);

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeTrue();
        }

        [Fact]
        public void ValueObjectsWithDifferentPropertiesShouldNotBeEqual()
        {
            // Arrange
            var first = new Options(true, 2, TransmissionType.Automatic);
            var second = new Options(true, 2, TransmissionType.Manual);

            // Act
            var result = first == second;

            // Arrange
            result.Should().BeFalse();
        }
    }
}

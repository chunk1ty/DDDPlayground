using Domain.Aggregates.CarAdAggregate;
using FluentAssertions;
using System;
using Xunit;

namespace UnitTests.Domain.Aggregates.CarAdAggregate
{
    public class CategoryTests
    {
        [Fact]
        public void ValidCategoryShouldNotThrowException()
        {
            // Act
            Action act = () => new Category("Valid name", "Valid description text");

            // Assert
            act.Should().NotThrow<ArgumentOutOfRangeException>();
        }

        [Fact]
        public void InvalidNameShouldThrowException()
        {
            // Act
            Action act = () => new Category("", "Valid description text");

            // Assert
            act.Should().Throw<ArgumentOutOfRangeException>();
        }
    }
}

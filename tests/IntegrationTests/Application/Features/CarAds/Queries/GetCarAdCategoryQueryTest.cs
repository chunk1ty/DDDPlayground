using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Threading.Tasks;
using FluentAssertions;
using Application.Features.CarAds.Queries.GetCarAdCategory;

namespace IntegrationTests.Application.Features.CarAds.Queries
{
    [TestFixture]
    public class GetCarAdCategoryQueryTest : BaseDatabaseFixture
    {
        [Test]
        public async Task Handle_WithCorrectQuery_ShouldReturn()
        {
            // Arrange
            IServiceScope scope = CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            // Act
            var command = new GetCarAdCategoryQuery();

            GetCarAdCategoryResponse[] carAds = await mediator.Send(command);

            // Assert
            carAds.Length.Should().BeGreaterThan(0);
        }
    }
}

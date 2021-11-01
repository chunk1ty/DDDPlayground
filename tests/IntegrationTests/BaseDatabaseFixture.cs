using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;

namespace IntegrationTests
{
    [TestFixture]
    public abstract class BaseDatabaseFixture
    {
        private ServiceProvider _container;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            var services = new ServiceCollection();

            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            services.AddInfrastructure(configuration);

            _container = services.BuildServiceProvider(validateScopes: true);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            
        }

        protected IServiceScope CreateScope()
        {
            return _container.CreateScope();
        }
    }
}
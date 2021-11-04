using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace IntegrationTests
{
    public class CarRentalDbContextFactory : IDesignTimeDbContextFactory<CarRentalDbContext>
    {
        public CarRentalDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CarRentalDbContext>();

            IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

            optionsBuilder.UseSqlServer(configuration.GetValue<string>("ConnectionStrings:DatabaseConnection"));

            return new CarRentalDbContext(optionsBuilder.Options, null);
        }
    }
}

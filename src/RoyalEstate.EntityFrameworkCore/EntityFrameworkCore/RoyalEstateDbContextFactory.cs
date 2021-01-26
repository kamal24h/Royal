using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using RoyalEstate.Configuration;
using RoyalEstate.Web;

namespace RoyalEstate.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class RoyalEstateDbContextFactory : IDesignTimeDbContextFactory<RoyalEstateDbContext>
    {
        public RoyalEstateDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<RoyalEstateDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            RoyalEstateDbContextConfigurer.Configure(builder, configuration.GetConnectionString(RoyalEstateConsts.ConnectionStringName));

            return new RoyalEstateDbContext(builder.Options);
        }
    }
}

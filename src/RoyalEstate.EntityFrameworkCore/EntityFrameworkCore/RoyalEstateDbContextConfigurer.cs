using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace RoyalEstate.EntityFrameworkCore
{
    public static class RoyalEstateDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<RoyalEstateDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<RoyalEstateDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}

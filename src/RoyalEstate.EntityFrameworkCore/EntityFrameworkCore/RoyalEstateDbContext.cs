using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using RoyalEstate.Authorization.Roles;
using RoyalEstate.Authorization.Users;
using RoyalEstate.MultiTenancy;

namespace RoyalEstate.EntityFrameworkCore
{
    public class RoyalEstateDbContext : AbpZeroDbContext<Tenant, Role, User, RoyalEstateDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public RoyalEstateDbContext(DbContextOptions<RoyalEstateDbContext> options)
            : base(options)
        {
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using RoyalEstate.Authorization.Roles;
using RoyalEstate.Authorization.Users;
using RoyalEstate.MultiTenancy;
using RoyalEstate.Entities;
using System.Collections.Generic;

namespace RoyalEstate.EntityFrameworkCore
{
    public class RoyalEstateDbContext : AbpZeroDbContext<Tenant, Role, User, RoyalEstateDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<EstateType> EstateTypes { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<Estate> Estates { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<EstateImage> EstateImages { get; set; }

        public RoyalEstateDbContext(DbContextOptions<RoyalEstateDbContext> options)
            : base(options)
        {
            
        }

        
    }
}

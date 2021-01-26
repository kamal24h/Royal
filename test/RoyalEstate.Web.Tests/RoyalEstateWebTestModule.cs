using Abp.AspNetCore;
using Abp.AspNetCore.TestBase;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RoyalEstate.EntityFrameworkCore;
using RoyalEstate.Web.Startup;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace RoyalEstate.Web.Tests
{
    [DependsOn(
        typeof(RoyalEstateWebMvcModule),
        typeof(AbpAspNetCoreTestBaseModule)
    )]
    public class RoyalEstateWebTestModule : AbpModule
    {
        public RoyalEstateWebTestModule(RoyalEstateEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbContextRegistration = true;
        } 
        
        public override void PreInitialize()
        {
            Configuration.UnitOfWork.IsTransactional = false; //EF Core InMemory DB does not support transactions.
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RoyalEstateWebTestModule).GetAssembly());
        }
        
        public override void PostInitialize()
        {
            IocManager.Resolve<ApplicationPartManager>()
                .AddApplicationPartsIfNotAddedBefore(typeof(RoyalEstateWebMvcModule).Assembly);
        }
    }
}
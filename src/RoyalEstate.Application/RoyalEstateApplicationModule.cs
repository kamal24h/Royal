using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RoyalEstate.Authorization;

namespace RoyalEstate
{
    [DependsOn(
        typeof(RoyalEstateCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class RoyalEstateApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<RoyalEstateAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(RoyalEstateApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}

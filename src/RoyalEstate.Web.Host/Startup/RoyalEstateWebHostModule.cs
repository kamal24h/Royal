using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RoyalEstate.Configuration;

namespace RoyalEstate.Web.Host.Startup
{
    [DependsOn(
       typeof(RoyalEstateWebCoreModule))]
    public class RoyalEstateWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public RoyalEstateWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(RoyalEstateWebHostModule).GetAssembly());
        }
    }
}

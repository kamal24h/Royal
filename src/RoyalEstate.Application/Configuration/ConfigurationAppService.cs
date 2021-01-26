using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using RoyalEstate.Configuration.Dto;

namespace RoyalEstate.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : RoyalEstateAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

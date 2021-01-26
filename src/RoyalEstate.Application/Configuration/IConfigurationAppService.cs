using System.Threading.Tasks;
using RoyalEstate.Configuration.Dto;

namespace RoyalEstate.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace RoyalEstate.Controllers
{
    public abstract class RoyalEstateControllerBase: AbpController
    {
        protected RoyalEstateControllerBase()
        {
            LocalizationSourceName = RoyalEstateConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

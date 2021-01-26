using Abp.AspNetCore.Mvc.ViewComponents;

namespace RoyalEstate.Web.Views
{
    public abstract class RoyalEstateViewComponent : AbpViewComponent
    {
        protected RoyalEstateViewComponent()
        {
            LocalizationSourceName = RoyalEstateConsts.LocalizationSourceName;
        }
    }
}

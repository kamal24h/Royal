using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace RoyalEstate.Web.Views
{
    public abstract class RoyalEstateRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected RoyalEstateRazorPage()
        {
            LocalizationSourceName = RoyalEstateConsts.LocalizationSourceName;
        }
    }
}

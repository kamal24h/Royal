using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using RoyalEstate.Authorization;

namespace RoyalEstate.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class RoyalEstateNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fas fa-home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "fas fa-building",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "fas fa-theater-masks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
                            )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "About",
                        icon: "fas fa-info-circle"                 
                        )                    
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Estates,
                        L("Estates"),
                        url: "Estates/Index",
                        icon: "fas fa-building"
                        )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.EstateTypes,
                        L("EstateTypes"),
                        url: "Estates/EstateTypes",
                        icon: "fas fa-cogs"
                    )
                ).AddItem(new MenuItemDefinition(
                        PageNames.CitiesAndProvinces,
                        L("CitiesAndProvinces"),
                        icon:"fas fa-map"
                    ).AddItem(new MenuItemDefinition(
                            PageNames.Cities,
                            L("Cities"),
                            url:"Cities/Index",
                            icon:"fas fa-city"
                        )
                    ).AddItem(new MenuItemDefinition(
                            PageNames.Provinces,
                            L("Provinces"),
                            url:"Provinces/Index",
                            icon:"fas fa-map"
                        )
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, RoyalEstateConsts.LocalizationSourceName);
        }
    }
}

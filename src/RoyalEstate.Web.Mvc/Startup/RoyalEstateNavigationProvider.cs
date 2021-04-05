using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using RoyalEstate.Authorization;
using StackExchange.Redis;

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
                        requiresAuthentication: true,
                        order:1
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Estates,
                        L("Estates"),
                        url: "Estates/Index",
                        icon: "fas fa-building",
                        order:2
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.EstatesQuickLoad,
                        L("EstatesQuickLoad"),
                        url: "Estates/Index/?quickLoad=true",
                        icon: "fas fa-building",
                        order: 3
                    )
                ).AddItem(new MenuItemDefinition(
                        PageNames.BaseInformation,
                        L("BaseInformation"),
                        icon: "fas fa-map",
                        order:4
                    ).AddItem(new MenuItemDefinition(
                        PageNames.Customers,
                        L("Customers"),
                        url: "Customers",
                        icon: "fas fa-users",
                        /*permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users),*/ 
                        order: 1
                        )
                    ).AddItem(
                    new MenuItemDefinition(
                        PageNames.EstateTypes,
                        L("EstateTypes"),
                        url: "Estates/EstateTypes",
                        icon: "fas fa-cogs",
                        order: 2
                        )
                   )
                    //.AddItem(new MenuItemDefinition(
                    //        PageNames.Provinces,
                    //        L("Provinces"),
                    //        url: "Provinces/Index",
                    //        icon: "fas fa-map",
                    //        order:2
                    //    )
                    //)
                    .AddItem(new MenuItemDefinition(
                            PageNames.Cities,
                            L("Cities"),
                            url: "Cities/Index",
                            icon: "fas fa-city",
                            order: 3
                        )
                    ).AddItem(new MenuItemDefinition(
                            PageNames.Districts,
                            L("District"),
                            url: "Districts/Index",
                            icon: "fas fa-city",
                            order: 4
                        )
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users),
                        order:5
                    ).AddItem(new MenuItemDefinition(
                        PageNames.SystemUsers,
                        L("SystemUsers"),
                        url: "Users",
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users), order:1)
                    )
                )/*.AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "fas fa-building",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)
                    )
                )*/.AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "fas fa-theater-masks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles),
                        order:6)
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "About",
                        icon: "fas fa-info-circle", order:7)                    
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, RoyalEstateConsts.LocalizationSourceName);
        }
    }
}

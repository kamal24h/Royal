using Abp.Authorization;
using Abp.Localization;
using Abp.MultiTenancy;

namespace RoyalEstate.Authorization
{
    public class RoyalEstateAuthorizationProvider : AuthorizationProvider
    {
        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            context.CreatePermission(PermissionNames.Pages_Users, L("Users"));
            context.CreatePermission(PermissionNames.Pages_Roles, L("Roles"));
            context.CreatePermission(PermissionNames.Pages_Estates, L("Estates"));
            context.CreatePermission(PermissionNames.Pages_ViewEstates, L("ViewEstates"));
            context.CreatePermission(PermissionNames.Pages_Tenants, L("Tenants"), multiTenancySides: MultiTenancySides.Host);
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, RoyalEstateConsts.LocalizationSourceName);
        }
    }
}

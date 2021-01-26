using Abp.Authorization;
using RoyalEstate.Authorization.Roles;
using RoyalEstate.Authorization.Users;

namespace RoyalEstate.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}

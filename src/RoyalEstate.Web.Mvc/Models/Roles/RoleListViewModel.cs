using System.Collections.Generic;
using RoyalEstate.Roles.Dto;

namespace RoyalEstate.Web.Models.Roles
{
    public class RoleListViewModel
    {
        public IReadOnlyList<PermissionDto> Permissions { get; set; }
    }
}

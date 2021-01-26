using System.Collections.Generic;
using RoyalEstate.Roles.Dto;

namespace RoyalEstate.Web.Models.Users
{
    public class UserListViewModel
    {
        public IReadOnlyList<RoleDto> Roles { get; set; }
    }
}

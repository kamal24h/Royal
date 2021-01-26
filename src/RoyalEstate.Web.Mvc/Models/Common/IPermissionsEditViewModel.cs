using System.Collections.Generic;
using RoyalEstate.Roles.Dto;

namespace RoyalEstate.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}
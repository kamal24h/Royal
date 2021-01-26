using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RoyalEstate.Roles.Dto;
using RoyalEstate.Users.Dto;

namespace RoyalEstate.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);

        Task<bool> ChangePassword(ChangePasswordDto input);
    }
}

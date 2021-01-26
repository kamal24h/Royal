using System.Threading.Tasks;
using Abp.Application.Services;
using RoyalEstate.Authorization.Accounts.Dto;

namespace RoyalEstate.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

using System.Threading.Tasks;
using Abp.Application.Services;
using RoyalEstate.Sessions.Dto;

namespace RoyalEstate.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

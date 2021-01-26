using Abp.Application.Services;
using RoyalEstate.MultiTenancy.Dto;

namespace RoyalEstate.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


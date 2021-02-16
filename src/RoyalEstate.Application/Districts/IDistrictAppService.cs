using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalEstate.Districts.Dto;

namespace RoyalEstate.Districts
{
    public interface IDistrictAppService : IAsyncCrudAppService<DistrictDto, int, PagedDistrictResultRequestDto, CreateDistrictDto, DistrictDto>
    {
        Task<List<SelectListItem>> GetDistrictsSelectListAsync(int cityId);
    }
}

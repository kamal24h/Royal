using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalEstate.Provinces.Dto;

namespace RoyalEstate.Provinces
{
    public interface IProvinceAppService : IAsyncCrudAppService<ProvinceDto, int, PagedProvinceResultRequestDto, CreateProvinceDto, ProvinceDto>
    {
        Task<List<SelectListItem>> GetProvincesSelectList(PagedProvinceResultRequestDto input);
    }
}

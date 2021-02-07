using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalEstate.Cities.Dto;

namespace RoyalEstate.Cities
{
    public interface ICityAppService : IAsyncCrudAppService<CityDto, int, PagedCityResultRequestDto, CreateCityDto, CityDto>
    {
        Task<List<SelectListItem>> GetCitiesSelectList(PagedCityResultRequestDto input);
    }
}

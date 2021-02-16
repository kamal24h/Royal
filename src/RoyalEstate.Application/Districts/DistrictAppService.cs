using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalEstate.Districts.Dto;
using RoyalEstate.Entities;

namespace RoyalEstate.Districts
{
    public class DistrictAppService : AsyncCrudAppService<District, DistrictDto, int, PagedDistrictResultRequestDto, CreateDistrictDto, DistrictDto>, IDistrictAppService
    {
        public DistrictAppService(IRepository<District, int> repository) : base(repository)
        {
        }

        public async Task<List<SelectListItem>> GetDistrictsSelectListAsync(int cityId)
        {
            return (await Repository.GetAllListAsync(d=>d.CityId==cityId && d.IsActive)).Select(d=>new SelectListItem{Text = d.Name, Value = d.Id.ToString()}).ToList();
        }
    }
}

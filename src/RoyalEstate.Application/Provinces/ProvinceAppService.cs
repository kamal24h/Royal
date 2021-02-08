using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalEstate.Entities;
using RoyalEstate.Provinces.Dto;

namespace RoyalEstate.Provinces
{
    public class ProvinceAppService :AsyncCrudAppService<Province, ProvinceDto, int, PagedProvinceResultRequestDto, CreateProvinceDto, ProvinceDto>, IProvinceAppService
    {
        public ProvinceAppService(IRepository<Province, int> repository) : base(repository)
        {
        }

        public async Task<List<SelectListItem>> GetProvincesSelectList(PagedProvinceResultRequestDto input)
        {
            return (await GetAllAsync(input)).Items
                .Select(p => new SelectListItem {Value = p.Id.ToString(), Text = p.Name}).ToList();
        }
    }
}

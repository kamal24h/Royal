﻿using System;
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

        public async Task<List<SelectListItem>> GetDistrictsSelectList(PagedDistrictResultRequestDto input)
        {
            return (await GetAllAsync(input)).Items.OrderBy(c=>c.Id).Select(c => new SelectListItem {Text = c.Name, Value = c.Id.ToString()}).ToList();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalEstate.Cities.Dto;
using RoyalEstate.Entities;

namespace RoyalEstate.Cities
{
    public class CityAppService : AsyncCrudAppService<City, CityDto, int, PagedCityResultRequestDto, CreateCityDto, CityDto>, ICityAppService
    {
        public CityAppService(IRepository<City, int> repository) : base(repository)
        {
        }

        public async Task<List<SelectListItem>> GetCitiesSelectList(PagedCityResultRequestDto input)
        {
            return (await GetAllAsync(input)).Items.OrderBy(c=>c.Name).Select(c => new SelectListItem {Text = c.Name, Value = c.Id.ToString()}).ToList();
        }
    }
}
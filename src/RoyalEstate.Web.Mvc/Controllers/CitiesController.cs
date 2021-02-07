using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalEstate.Cities;
using RoyalEstate.Controllers;
using RoyalEstate.Provinces;
using RoyalEstate.Provinces.Dto;
using RoyalEstate.Web.Models.Cities;

namespace RoyalEstate.Web.Controllers
{
    public class CitiesController : RoyalEstateControllerBase
    {
        private readonly ICityAppService _cityAppService;
        private readonly IProvinceAppService _provinceAppService;

        public CitiesController(
            ICityAppService cityAppService, 
            IProvinceAppService provinceAppService)
        {
            _cityAppService = cityAppService;
            _provinceAppService = provinceAppService;
        }

        public async Task<IActionResult> Index()
        {
            CitiesIndexVm model = new CitiesIndexVm();
            model.Provinces.AddRange(await _provinceAppService.GetProvincesSelectList(new PagedProvinceResultRequestDto()));

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditModal(int id)
        {

            EditCityVm model = new EditCityVm()
            {
                City = await _cityAppService.GetAsync(new EntityDto<int>(id)),
                Provinces = await _provinceAppService.GetProvincesSelectList(new PagedProvinceResultRequestDto())
            };
            return PartialView("_EditCityModal", model);
        }
    }
}

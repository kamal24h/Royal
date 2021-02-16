using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalEstate.Controllers;
using RoyalEstate.Cities;
using RoyalEstate.Cities.Dto;
using RoyalEstate.Districts;
using RoyalEstate.Web.Models.Districts;

namespace RoyalEstate.Web.Controllers
{
    public class DistrictsController : RoyalEstateControllerBase
    {
        private readonly IDistrictAppService _DistrictAppService;
        private readonly ICityAppService _cityAppService;

        public DistrictsController(
            IDistrictAppService DistrictAppService, 
            ICityAppService cityAppService)
        {
            _DistrictAppService = DistrictAppService;
            _cityAppService = cityAppService;
        }

        public async Task<IActionResult> Index()
        {
            DistrictsIndexVm model = new DistrictsIndexVm();
            model.Cities.AddRange(await _cityAppService.GetCitiesSelectList());

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> EditModal(int id)
        {

            EditDistrictVm model = new EditDistrictVm()
            {
                District = await _DistrictAppService.GetAsync(new EntityDto<int>(id)),
                Cities = await _cityAppService.GetCitiesSelectList()
            };
            return PartialView("_EditDistrictModal", model);
        }
    }
}

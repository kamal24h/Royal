using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoyalEstate.Cities;
using RoyalEstate.Controllers;
using RoyalEstate.Provinces;

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

        public IActionResult Index()
        {
            return View();
        }
    }
}

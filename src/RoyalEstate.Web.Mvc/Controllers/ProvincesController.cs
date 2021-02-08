using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoyalEstate.Controllers;
using RoyalEstate.Provinces;

namespace RoyalEstate.Web.Controllers
{
    public class ProvincesController : RoyalEstateControllerBase
    {
        private readonly IProvinceAppService _provinceAppService;

        public ProvincesController(IProvinceAppService provinceAppService)
        {
            _provinceAppService = provinceAppService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

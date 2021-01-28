using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using RoyalEstate.Authorization;
using RoyalEstate.Controllers;
using RoyalEstate.Estates;
using RoyalEstate.Web.Models.Estates;
using RoyalEstate.Entities;
using System.Collections.Generic;

namespace RoyalEstate.Web.Controllers
{
    public class EstatesController : RoyalEstateControllerBase
    {
        public IActionResult Index()
        {
            List<EstateType> estateType = new List<EstateType>();
            return View(estateType);
        }
    }
}

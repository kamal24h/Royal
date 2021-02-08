using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoyalEstate.Cities;
using RoyalEstate.Cities.Dto;
using RoyalEstate.Controllers;
using RoyalEstate.Customers;
using RoyalEstate.Customers.Dto;

namespace RoyalEstate.Web.Controllers
{
    public class CustomersController : RoyalEstateControllerBase
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly ICityAppService _cityAppService;

        public CustomersController(
            ICustomerAppService customerAppService,
            ICityAppService cityAppService)
        {
            _customerAppService = customerAppService;
            _cityAppService = cityAppService;
        }

        public async Task<IActionResult> Index()
        {
            CreateCustomerDto model = new CreateCustomerDto()
            {
                Cities = await _cityAppService.GetCitiesSelectList(new PagedCityResultRequestDto())
            };
            return View(model);
        }
    }
}

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
using Abp.Application.Services.Dto;
using RoyalEstate.Estates;
using RoyalEstate.Estates.Dto;

namespace RoyalEstate.Web.Controllers
{
    public class CustomersController : RoyalEstateControllerBase
    {
        private readonly ICustomerAppService _customerAppService;
        private readonly ICityAppService _cityAppService;
        private readonly IEstateAppService _estateAppService;

        public CustomersController(
            ICustomerAppService customerAppService,
            ICityAppService cityAppService,
            IEstateAppService estateAppService)
        {
            _customerAppService = customerAppService;
            _cityAppService = cityAppService;
            _estateAppService = estateAppService;
        }

        public async Task<IActionResult> Index()
        {
            CreateCustomerDto model = new CreateCustomerDto()
            {
                Cities = await _cityAppService.GetCitiesSelectList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GetCustomerDetails(long id)
        {            
            var customer = await _customerAppService.GetAsync(new EntityDto<long>(id));
            return PartialView("_CustomerDetailsModal", customer);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> DeleteCustomer(long id, bool withEstates)
        {
            try
            {
                var customer = await _customerAppService.GetAsync(new EntityDto<long>(id));
                customer.IsActive = false;
                await _customerAppService.UpdateAsync(customer);
                if (withEstates)
                {
                    var estates = await _estateAppService.GetAllWithoutPagingAsync(new GetAllEstatesInputDto { CustomerId = id, IsActive = true });
                    estates.ForEach(async e =>
                    {
                        e.IsActive = false;
                        await _estateAppService.UpdateAsync(e);
                    });
                }
                return Json(new
                {
                    code = 0,
                    msg = L("SuccessfullyDeleted")
                });
            }
            catch (Exception)
            {
                return Json(new
                {
                    code = 1,
                    msg = L("SomethingWentWrong")
                });
            }
        }
    }
}

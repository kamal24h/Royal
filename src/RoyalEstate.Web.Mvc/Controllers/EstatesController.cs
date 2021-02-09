using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalEstate.Cities;
using RoyalEstate.Cities.Dto;
using RoyalEstate.Web.Models.Estates;
using RoyalEstate.Controllers;
using RoyalEstate.Customers;
using RoyalEstate.Customers.Dto;
using RoyalEstate.Estates.Dto;
using RoyalEstate.Estates;

namespace RoyalEstate.Web.Controllers
{
    public class EstatesController : RoyalEstateControllerBase
    {
        private readonly IEstateTypeAppService _estateTypeAppService;
        private readonly IEstateAppService _estateAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly ICityAppService _cityAppService;

        public EstatesController(
            IEstateTypeAppService estateTypeAppService, 
            IEstateAppService estateAppService,
            ICustomerAppService customerAppService,
            ICityAppService cityAppService)
        {
            _estateTypeAppService = estateTypeAppService;
            _estateAppService = estateAppService;
            _customerAppService = customerAppService;
            _cityAppService = cityAppService;
        }

        public async Task<ActionResult> EstateTypes()
        {
            var types = (await _estateTypeAppService.GetEstateTypeNames()).Items;
            var model = new EstateTypeListViewModel
            {
                EstateTypes = types
            };            
            return View(model);
        }

        public async Task<ActionResult> EditEstateTypeModal(int estateTypeId)
        {
            var estateType = await _estateTypeAppService.GetAsync(new EntityDto<int>(estateTypeId));
            
            var model = new EditEstateTypeModalViewModel
            {
                EstateType = estateType                
            };
            return PartialView("_EditEstateTypeModal", model);
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewEstate(int estateTypeId, int serviceTypeId)
        {
            CreateEstateVm model = new CreateEstateVm
            {
                CreateEstateDto = new CreateEstateDto()
                {
                    ServiceTypeId = serviceTypeId, 
                    EstateTypeId = estateTypeId
                },
                Customers = await _customerAppService.GetCustomersSelectListAsync(),
                Cities = await _cityAppService.GetCitiesSelectList(new PagedCityResultRequestDto{IsActive = true})
            };

            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> CreateEstate(CreateEstateDto input)
        {
            try
            {
                if (input.Images.Count>0)
                {
                    var ticks = (DateTime.Now - new DateTime(2021, 1, 1)).Ticks.ToString();
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","img","Estates", ticks);
                    Directory.CreateDirectory(path);

                    int i = 1;
                    foreach (IFormFile file in input.Images.Where(f=>f.Length!=0))
                    {
                        string imageExt = Path.GetExtension(file.FileName);
                        await using (FileStream stream = new FileStream(Path.Combine(path, i + imageExt), FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                            input.ImagePaths.Add("/"+ Path.Combine("img", "Estates", ticks, i + imageExt).Replace('\\', '/'));
                        }
                        i++;
                    }
                }

                var estate = await _estateAppService.CreateAsync(input);
                return Json(new
                {
                    code = 0,
                    msg = "آگهی با موقیت ثبت شد"
                });

            }
            catch (Exception e)
            {
                return Json(new
                {
                    code = 1,
                    msg = "خطایی در سمت سرور رخ داد"
                });
            }
        }

        public async Task<ActionResult> Single(long id)
        {          
            
            EstateVm model = new EstateVm()
            {
                EstateDto = await _estateAppService.GetAsync(new EntityDto<long>(id))
            };
            return View(model);
        }
    }
}

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using DNTPersianUtils.Core;
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
using RoyalEstate.Districts;
using RoyalEstate.Districts.Dto;
using Abp.Domain.Repositories;
using RoyalEstate.Entities;
using Microsoft.EntityFrameworkCore;

namespace RoyalEstate.Web.Controllers
{
    public class EstatesController : RoyalEstateControllerBase
    {
        private readonly IEstateTypeAppService _estateTypeAppService;
        private readonly IEstateAppService _estateAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly IDistrictAppService _districtAppService;
        private readonly ICityAppService _cityAppService;
        private readonly IRepository<ServiceType> _serviceTypesRepo;

        public EstatesController(
            IEstateTypeAppService estateTypeAppService, 
            IEstateAppService estateAppService,
            ICustomerAppService customerAppService,
            IDistrictAppService districtAppService,
            ICityAppService cityAppService,
            IRepository<ServiceType> serviceTypesRepo)
        {
            _estateTypeAppService = estateTypeAppService;
            _estateAppService = estateAppService;
            _customerAppService = customerAppService;
            _districtAppService = districtAppService;
            _cityAppService = cityAppService;
            _serviceTypesRepo = serviceTypesRepo;
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



        public async Task<ActionResult> Index()
        {
            var serviceTypes = await _serviceTypesRepo.GetAllIncluding(s => s.EstateTypes).ToListAsync();            
            return View(serviceTypes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> NewEstate(int estateTypeId)
        {
            CreateEstateVm model = new CreateEstateVm
            {
                CreateEstateDto = new CreateEstateDto
                {
                    EstateTypeId = estateTypeId                  
                },
                Customers = await _customerAppService.GetCustomersSelectListAsync(),
                Cities = await _cityAppService.GetCitiesSelectList(),
                EstateType = await _estateTypeAppService.GetAsync(new EntityDto<int>(estateTypeId))
            };

            return View(model);
        }        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> CreateEstate([Bind(include:"CreateEstateDto")] CreateEstateVm model)
        {
            try
            {
                var input = model.CreateEstateDto;                    
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditEstate(long id)
        {
            EstateDto estateDto = await _estateAppService.GetAsync(new EntityDto<long>(id));
            EditEstateVm model = new EditEstateVm
            {
                EstateDto = estateDto,
                Customers = await _customerAppService.GetCustomersSelectListAsync(),
                Cities = await _cityAppService.GetCitiesSelectList(),
                EstateType = await _estateTypeAppService.GetAsync(new EntityDto<int>(estateDto.EstateTypeId))
            };
            return View(model);
        }

        /*public async Task<JsonResult> UpdateEstate([Bind(include: "EstateDto")] EditEstateVm model)
        {
            try
            {
                var input = model.EstateDto;
                if (input.Images.Count > 0)
                {                    
                    var ticks = (DateTime.Now - new DateTime(2021, 1, 1)).Ticks.ToString();
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "Estates", ticks);
                    Directory.CreateDirectory(path);

                    int i = 1;
                    foreach (IFormFile file in input.Images.Where(f => f.Length != 0))
                    {
                        string imageExt = Path.GetExtension(file.FileName);
                        await using (FileStream stream = new FileStream(Path.Combine(path, i + imageExt), FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                            input.ImagePaths.Add("/" + Path.Combine("img", "Estates", ticks, i + imageExt).Replace('\\', '/'));
                        }
                        i++;
                    }
                }

                await _estateAppService.UpdateAsync(input);
                return Json(new
                {
                    code = 0,
                    msg = "تغییرات با موفقیت ذخیره شد."
                });
            }
            catch(Exception e)
            {
                return Json(new
                {
                    code = 1,
                    msg = "خطایی در سمت سرور رخ داد."
                });
            }
        }*/

        [HttpPost]
        public async Task<JsonResult> GetDistricts(int cityId)
        {
            var districts = await _districtAppService.GetDistrictsSelectListAsync(cityId);
            return Json(new
            {
                results = districts.Select(d => new
                {
                    id = int.Parse(d.Value),
                    text = d.Text
                }).ToArray()
            });
        }        

        public async Task<ActionResult> Single(long id)
        {
            var estateDto = await _estateAppService.GetAsync(new EntityDto<long>(id));
            EstateVm model = new EstateVm()
            {
                EstateDto = estateDto,
                EstateTypeDto = await _estateTypeAppService.GetAsync(new EntityDto<int>(estateDto.EstateTypeId))
            };
            return View(model);
        }
    }
}

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
using Microsoft.AspNetCore.StaticFiles;
using System.Drawing.Imaging;
using System.Drawing;
using System.Text.RegularExpressions;
using RoyalEstate.Authorization;

namespace RoyalEstate.Web.Controllers
{
    
    public class EstatesController : RoyalEstateControllerBase
    {
        private readonly IEstateTypeAppService _estateTypeAppService;
        private readonly IEstateAppService _estateAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly IDistrictAppService _districtAppService;
        private readonly ICityAppService _cityAppService;
        private readonly IEstateCategoryAppService _estateCategoryAppService;

        public EstatesController(
            IEstateTypeAppService estateTypeAppService, 
            IEstateAppService estateAppService,
            ICustomerAppService customerAppService,
            IDistrictAppService districtAppService,
            ICityAppService cityAppService,
            IEstateCategoryAppService estateCategoryAppService)
        {
            _estateTypeAppService = estateTypeAppService;
            _estateAppService = estateAppService;
            _customerAppService = customerAppService;
            _districtAppService = districtAppService;
            _cityAppService = cityAppService;
            _estateCategoryAppService = estateCategoryAppService;
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

        [AbpMvcAuthorize(PermissionNames.Pages_Estates)]
        public async Task<ActionResult> EditEstateTypeModal(int estateTypeId)
        {
            var estateType = await _estateTypeAppService.GetAsync(new EntityDto<int>(estateTypeId));
            
            var model = new EditEstateTypeModalViewModel
            {
                EstateType = estateType                
            };
            return PartialView("_EditEstateTypeModal", model);
        }


        [AbpMvcAuthorize(PermissionNames.Pages_ViewEstates)]
        public async Task<ActionResult> Index(bool quickLoad = false)
        {
            var categories = await _estateCategoryAppService.GetAllAsync();
            ViewBag.QuickLoad = quickLoad;
            return View(categories);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AbpMvcAuthorize(PermissionNames.Pages_Estates)]
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
        [AbpMvcAuthorize(PermissionNames.Pages_Estates)]
        public async Task<JsonResult> CreateEstate([Bind(include:"CreateEstateDto")] CreateEstateVm model)
        {
            try
            {
                var input = model.CreateEstateDto;                    
                if (input.Images.Count>0)
                {
                    var ticks = (DateTime.Now - new DateTime(2021, 1, 1)).Ticks;
                    string ticksString = ticks.ToString();
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot","img","Estates", ticksString);
                    Directory.CreateDirectory(path);

                    // Create Thumbnail from first image
                    var firstImage = input.Images.First();
                    CreateThumbnail(firstImage, path);
                    ///////////////////

                    //Save images
                    int i = 1;
                    foreach (IFormFile file in input.Images.Where(f=>f.Length!=0))
                    {                        
                        string imageExt = Path.GetExtension(file.FileName);
                        await using (FileStream stream = new FileStream(Path.Combine(path, ticks + imageExt), FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                            input.ImagePaths.Add("/"+ Path.Combine("img", "Estates", ticksString, ticks + imageExt).Replace('\\', '/'));
                        }
                        ticks++;
                    }
                }

                input.OrderDate = DateTime.Today;
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
        [AbpMvcAuthorize(PermissionNames.Pages_Estates)]
        public async Task<ActionResult> EditEstate(long id)
        {
            EstateDto estateDto = await _estateAppService.GetAsync(new EntityDto<long>(id));

            EstateVm model = new EstateVm
            {
                EstateDto = estateDto,
                Customers = await _customerAppService.GetCustomersSelectListAsync(),
                Cities = await _cityAppService.GetCitiesSelectList(),
                EstateTypeDto = await _estateTypeAppService.GetAsync(new EntityDto<int>(estateDto.EstateTypeId))
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AbpMvcAuthorize(PermissionNames.Pages_Estates)]
        public async Task<JsonResult> UpdateEstate([Bind(include: "EstateDto")] EstateVm model)
        {
            try
            {
                var input = model.EstateDto;
                var files = Request.Form.Files;
                if (files!=null && files.Count > 0)
                {
                    var estate = await _estateAppService.GetAsync(new EntityDto<long>(input.Id));
                    long ticks = (DateTime.Now - new DateTime(2021, 1, 1)).Ticks;
                    string ticksString = ticks.ToString();
                    var folder = estate.ImagePaths.Count == 0
                        ? ticksString
                        : Regex.Match(input.ImagePaths[0], @"\/\d+\/").Value.Trim('/');
                    
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "Estates", folder);
                    Directory.CreateDirectory(path);

                    // Create Thumbnail from first image
                    if (input.ImagePaths.Count==0)
                    {
                        CreateThumbnail(files.First(), path);
                    }
                    else
                    {
                        CreateThumbnailFromFile(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", input.ImagePaths[0].Substring(1)));
                    }
                                                            
                    foreach (IFormFile file in files.Where(f => f.Length != 0))
                    {
                        string imageExt = Path.GetExtension(file.FileName);
                        await using (FileStream stream = new FileStream(Path.Combine(path, ticks + imageExt), FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                            input.ImagePaths.Add("/" + Path.Combine("img", "Estates", folder, ticks+ imageExt).Replace('\\', '/'));
                        }
                        ticks++;
                    }
                }

                input.OrderDate = DateTime.Today;
                await _estateAppService.UpdateAsync(input);
                return Json(new
                {
                    code = 0,
                    imagePaths = input.ImagePaths,
                    msg = "تغییرات با موفقیت ذخیره شد."
                });
            }
            catch (Exception e)
            {
                return Json(new
                {
                    code = 1,
                    msg = "خطایی در سمت سرور رخ داد."
                });
            }
        }

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

        [NonAction]
        public async void CreateThumbnail(IFormFile file, string path)
        {
            string ext = Path.GetExtension(file.FileName);
            /*new FileExtensionContentTypeProvider().TryGetContentType(firstImage.FileName, out var contentType);
            long q = 35;
            EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, q);
            ImageCodecInfo imageCodec = ImageCodecInfo.GetImageEncoders().First(e => e.MimeType == contentType);
            EncoderParameters encoderParams = new EncoderParameters(1) {Param = {[0] = qualityParam}};*/
            await using (Stream stream = file.OpenReadStream())
            {
                Image thumbnail = Image.FromStream(stream).GetThumbnailImage(240, 120, () => false, IntPtr.Zero);
                await using FileStream fStream = new FileStream(Path.Combine(path, "thumbnail" + ext), FileMode.Create);
                thumbnail.Save(fStream, ImageFormat.Jpeg);
            }
        }

        [NonAction]
        public async void CreateThumbnailFromFile(string path)
        {
            
            /*new FileExtensionContentTypeProvider().TryGetContentType(firstImage.FileName, out var contentType);
            long q = 35;
            EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, q);
            ImageCodecInfo imageCodec = ImageCodecInfo.GetImageEncoders().First(e => e.MimeType == contentType);
            EncoderParameters encoderParams = new EncoderParameters(1) {Param = {[0] = qualityParam}};*/
            await using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                Image thumbnail = Image.FromStream(stream).GetThumbnailImage(240, 120, () => false, IntPtr.Zero);
                path = Regex.Replace(path, @"\/\d+\.", "/thumbnail.");
                await using FileStream fStream = new FileStream(path, FileMode.Create);
                thumbnail.Save(fStream, ImageFormat.Jpeg);
            }
        }
    }
}

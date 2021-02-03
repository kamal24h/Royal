using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using RoyalEstate.Web.Models.Estates;
using RoyalEstate.Controllers;
using RoyalEstate.Estates.Dto;
using RoyalEstate.Estates;

namespace RoyalEstate.Web.Controllers
{
    public class EstatesController : RoyalEstateControllerBase
    {
        private readonly IEstateTypeAppService _estateTypeAppServic;

        public EstatesController(IEstateTypeAppService estateTypeAppServic)
        {
            _estateTypeAppServic = estateTypeAppServic;
        }

        public async Task<ActionResult> IndexAsync()
        {
            var types = (await _estateTypeAppServic.GetEstateTypeNames()).Items;
            var model = new EstateTypeListViewModel
            {
                EstateTypes = types
            };            
            return View(model);
        }

        public async Task<ActionResult> EditModal(int estateTypeId)
        {
            var estateType = await _estateTypeAppServic.GetAsync(new EntityDto<int>(estateTypeId));
            
            var model = new EditEstateTypeModalViewModel
            {
                EstateType = estateType                
            };
            return PartialView("_EditModal", model);
        }
    }
}

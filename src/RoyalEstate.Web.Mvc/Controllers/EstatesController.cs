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
        private readonly IEstateAppService _estateAppServic;

        public EstatesController(IEstateAppService estateAppServic)
        {
            _estateAppServic = estateAppServic;
        }

        public async Task<ActionResult> IndexAsync()
        {
            var types = (await _estateAppServic.GetEstateTypeNames()).Items;
            var model = new EstateListViewModel
            {
                EstateTypes = types
            };            
            return View(model);
        }

        public async Task<ActionResult> EditModal(int typeId)
        {
            var estateType = await _estateAppServic.GetAsync(new EntityDto<int>(typeId));
            
            var model = new EditEstateTypeModalViewModel
            {
                EstateType = estateType                
            };
            return PartialView("_EditModal", model);
        }
    }
}

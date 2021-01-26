using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using RoyalEstate.Controllers;

namespace RoyalEstate.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : RoyalEstateControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}

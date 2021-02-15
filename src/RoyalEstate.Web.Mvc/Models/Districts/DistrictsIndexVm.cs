using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RoyalEstate.Web.Models.Districts
{
    public class DistrictsIndexVm
    {
        public DistrictsIndexVm()
        {
            Cities = new List<SelectListItem>()
            {
                new SelectListItem {Value = "", Text = "همه"}
            };
        }
        public List<SelectListItem> Cities { get; set; }
    }
}

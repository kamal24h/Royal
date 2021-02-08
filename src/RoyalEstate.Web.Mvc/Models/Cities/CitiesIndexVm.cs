using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RoyalEstate.Web.Models.Cities
{
    public class CitiesIndexVm
    {
        public CitiesIndexVm()
        {
            Provinces = new List<SelectListItem>()
            {
                new SelectListItem {Value = "", Text = "همه"}
            };
        }
        public List<SelectListItem> Provinces { get; set; }
    }
}

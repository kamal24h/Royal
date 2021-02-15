using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalEstate.Cities.Dto;
using RoyalEstate.Districts.Dto;

namespace RoyalEstate.Web.Models.Districts
    {
    public class EditDistrictVm
    {
        public EditDistrictVm()
        {
            Cities = new List<SelectListItem>();
        }
        public DistrictDto District { get; set; }
        public List<SelectListItem> Cities { get; set; }
    }
}

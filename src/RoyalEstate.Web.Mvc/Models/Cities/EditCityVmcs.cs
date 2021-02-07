using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalEstate.Cities.Dto;

namespace RoyalEstate.Web.Models.Cities
{
    public class EditCityVm
    {
        public EditCityVm()
        {
            Provinces = new List<SelectListItem>();
        }
        public CityDto City { get; set; }
        public List<SelectListItem> Provinces { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalEstate.Cities.Dto;
using RoyalEstate.Estates.Dto;

namespace RoyalEstate.Web.Models.Estates
{
    public class EstateVm
    {
        public EstateDto EstateDto { get; set; }
        public EstateTypeDto EstateTypeDto { get; set; }
        public List<SelectListItem> Customers { get; set; }
        public List<SelectListItem> Districts { get; set; }
        public List<SelectListItem> Cities { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }
}

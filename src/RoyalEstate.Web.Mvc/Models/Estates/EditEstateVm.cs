using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalEstate.Estates.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoyalEstate.Web.Models.Estates
{
    public class EditEstateVm
    {
        public EditEstateDto EditEstateDto { get; set; }
        public EstateTypeDto EstateType { get; set; }
        public List<SelectListItem> Cities { get; set; }
        public List<SelectListItem> Districts { get; set; }
        public List<SelectListItem> Customers { get; set; }
    }
}

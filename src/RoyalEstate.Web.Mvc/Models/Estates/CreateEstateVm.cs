using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalEstate.Estates.Dto;

namespace RoyalEstate.Web.Models.Estates
{
    public class CreateEstateVm
    {
        public CreateEstateDto CreateEstateDto { get; set; }
        public List<SelectListItem> Cities { get; set; }
        public List<SelectListItem> Customers { get; set; }
    }
}

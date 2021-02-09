using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RoyalEstate.Estates.Dto;

namespace RoyalEstate.Web.Models.Estates
{
    public class EstateVm
    {
        public EstateDto EstateDto { get; set; }
        public bool CanEdit { get; set; }
        public bool CanDelete { get; set; }
    }
}

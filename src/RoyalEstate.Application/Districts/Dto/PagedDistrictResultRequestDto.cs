using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace RoyalEstate.Districts.Dto
{
    public class PagedDistrictResultRequestDto
    {
        public bool? IsActive { get; set; }
        public int? CityId { get; set; }
    }
}

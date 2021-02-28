using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace RoyalEstate.Cities.Dto
{
    public class PagedCityResultRequestDto
    {
        public bool? IsActive { get; set; }
        public int? ProvinceId { get; set; }
    }
}

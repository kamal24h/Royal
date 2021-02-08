using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace RoyalEstate.Provinces.Dto
{
    public class PagedProvinceResultRequestDto : PagedResultRequestDto
    {
        public bool IsActive { get; set; }
    }
}

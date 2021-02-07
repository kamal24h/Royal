using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace RoyalEstate.Cities.Dto
{
    public class PagedCityResultRequestDto : PagedResultRequestDto
    {
        public bool IsActive { get; set; }
    }
}

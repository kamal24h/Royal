using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace RoyalEstate.Customers.Dto
{
    public class GetAllCustomersInputDto : PagedAndSortedResultRequestDto
    {
        public string Term { get; set; }
        public bool? IsActive { get; set; }

    }
}

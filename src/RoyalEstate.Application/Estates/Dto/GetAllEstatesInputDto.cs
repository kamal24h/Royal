using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace RoyalEstate.Estates.Dto
{
    public class GetAllEstatesInputDto : PagedAndSortedResultRequestDto
    {
        public bool? IsActive { get; set; }
        public string Term { get; set; }
        public int? EstateTypeId { get; set; }
        public int? CityId { get; set; }
        public int? DistrictId { get; set; }
        public double? MinArea { get; set; }
        public double? MaxArea { get; set; }
        public int? Rooms { get; set; }
        public int? Floor { get; set; }
        public bool Elevator { get; set; }
        public bool Parking { get; set; }
        public long? MinPrice { get; set; }
        public long? MaxPrice { get; set; }
        public long? MinRent { get; set; }
        public long? MaxRent { get; set; }
        public long? MinDeposit { get; set; }
        public long? MaxDeposit { get; set; }
        public long? CustomerId { get; set; }
    }
}

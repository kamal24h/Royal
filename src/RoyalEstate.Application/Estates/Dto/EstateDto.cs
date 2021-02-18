using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Timing;
using Microsoft.AspNetCore.Http;
using RoyalEstate.Entities;

namespace RoyalEstate.Estates.Dto
{
    [AutoMapFrom(typeof(Estate))]
    public class EstateDto : AuditedEntityDto<long>
    {       
        public string Title { get; set; }

        public int EstateTypeId { get; set; }
        public double Area { get; set; }
        public int? Rooms { get; set; }
        public int? Floor { get; set; }
        public int? TotalFloors { get; set; }
        public int? UnitsPerFloor { get; set; }
        public bool? Parking { get; set; }
        public bool? StoreRoom { get; set; }
        public bool? Elevator { get; set; }
        public bool? MasterRoom { get; set; }
        public string LegalDoc { get; set; }
        public string BuiltDate { get; set; }
        public string FilingCode { get; set; }

        [DisableDateTimeNormalization]
        public DateTime CreationTime { get; set; }

        public long? Price { get; set; }
        public long? Rent { get; set; }
        public long? Deposit { get; set; }

        public int CityId { get; set; }
        public string CityName { get; set; }
        public int? DistrictId { get; set; }
        public string DistrictName { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerCellPhone1 { get; set; }
        public string CustomerPhoneNumber1 { get; set; }
        public string CustomerEmailAddress { get; set; }

        public string CreatorUserName { get; set; }
        public string CreatorUserSurname { get; set; }


        public string Address { get; set; }

        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public bool IsActive { get; set; }
        public string Description { get; set; }

        public List<string> ImagePaths { get; set; }        
    }
}

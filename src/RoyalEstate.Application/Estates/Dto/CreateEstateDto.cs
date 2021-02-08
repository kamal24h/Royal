using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using RoyalEstate.Entities;

namespace RoyalEstate.Estates.Dto
{
    [AutoMapTo(typeof(Estate))]
    public class CreateEstateDto
    {
        public CreateEstateDto()
        {
            ImagePaths = new List<string>();
            Images = new List<IFormFile>(); 
        }
        [Required(ErrorMessage = "عنوان آگهی را وارد کنید")]
        [MinLength(10, ErrorMessage = "حداقل 10 کاراکتر")]
        public string Title { get; set; }
        
        public int EstateTypeId { get; set; }
        public int ServiceTypeId { get; set; }

        public double Area { get; set; }
        public int? Rooms { get; set; }
        public int? Floor { get; set; }
        public int? TotalFloors { get; set; }
        public int? UnitsPerFloor { get; set; }
        public bool? Parking { get; set; }
        public bool? StoreRoom { get; set; }
        public bool? Elevator { get; set; }
        public string BuiltDate { get; set; }


        public long? Price { get; set; }
        public long? Rent { get; set; }
        public long? Deposit { get; set; }
        
        public int CityId { get; set; }
        public long CustomerId { get; set; }

        [Required(ErrorMessage = "آدرس را وارد کنید")]
        [MaxLength(500, ErrorMessage = "حداکثر 500 کاراکتر")]
        public string Address { get; set; }

        public double? Longitude { get; set; }
        public double? Latitude { get; set; }


        public bool IsActive { get; set; }

        [MaxLength(500,ErrorMessage = "حداکثر 500 کاراکتر")]
        public string Description { get; set; }

        public List<string> ImagePaths { get; set; }
        public List<IFormFile> Images { get; set; }
    }
}

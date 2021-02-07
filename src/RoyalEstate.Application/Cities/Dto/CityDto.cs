using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using RoyalEstate.Entities;

namespace RoyalEstate.Cities.Dto
{
    [AutoMapFrom(typeof(City))]
    public class CityDto : EntityDto
    {
        [Required]
        public string Name { get; set; }
        public string ProvinceName { get; set; }
        [Required]
        public string ProvinceId { get; set; }

        [DisplayName("فعال")]
        public bool IsActive { get; set; }
    }
}

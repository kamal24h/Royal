using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using RoyalEstate.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RoyalEstate.Districts.Dto
{   
    [AutoMapFrom(typeof(District))]
    public class DistrictDto : EntityDto
    {
        [Required]
        public string Name { get; set; }
        
        public string CityName { get; set; }
        [Required]
        public string CityId { get; set; }

        [DisplayName("فعال")]
        public bool IsActive { get; set; }
    }
}

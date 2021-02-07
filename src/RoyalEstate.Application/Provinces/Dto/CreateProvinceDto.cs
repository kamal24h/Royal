using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.AutoMapper;
using RoyalEstate.Entities;

namespace RoyalEstate.Provinces.Dto
{
    [AutoMapTo(typeof(Province))]
    public class CreateProvinceDto
    {
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}

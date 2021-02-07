using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using RoyalEstate.Entities;

namespace RoyalEstate.Provinces.Dto
{
    [AutoMapFrom(typeof(Province))]
    public class ProvinceDto : EntityDto
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}

using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using RoyalEstate.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace RoyalEstate.Estates.Dto
{
    [AutoMapFrom(typeof(ServiceType))]
    public class EstateCategoryDto : EntityDto
    {
        public EstateCategoryDto()
        {
            EstateTypes = new List<EstateTypeDto>();
        }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public List<EstateTypeDto> EstateTypes { get; set; }
    }
}

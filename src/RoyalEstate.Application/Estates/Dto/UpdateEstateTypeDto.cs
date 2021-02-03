using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using RoyalEstate.Entities;

namespace RoyalEstate.Estates.Dto
{
    [AutoMapTo(typeof(EstateType))]
    public class UpdateEstateTypeDto : EntityDto
    {
        public const int MaxNameLength = 100;

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}

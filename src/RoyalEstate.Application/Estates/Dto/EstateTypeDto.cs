using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using RoyalEstate.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RoyalEstate.Estates.Dto
{
    [AutoMapFrom(typeof(EstateType))]
    public class EstateTypeDto : EntityDto
    {
        public const int MaxNameLength = 100;

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        public DateTime CreationTime { get; set; }

        public bool IsActive { get; set; }
    }
}

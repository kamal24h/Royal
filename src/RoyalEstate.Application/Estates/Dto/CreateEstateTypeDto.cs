using Abp.AutoMapper;
using Abp.Runtime.Validation;
using RoyalEstate.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RoyalEstate.Estates.Dto
{
    [AutoMapTo(typeof(EstateType))]
    public class CreateEstateTypeDto
    {
        public const int MaxNameLength = 256;

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        public DateTime CreationTime { get; set; }

        public bool IsActive { get; set; }
    }
}

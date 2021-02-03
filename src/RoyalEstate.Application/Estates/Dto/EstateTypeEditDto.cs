using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RoyalEstate.Estates.Dto
{
    public class EstateTypeEditDto : EntityDto<int>
    {
        public const int MaxNameLength = 100;

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        public DateTime CreationTime { get; set; }

        public bool IsActive { get; set; }
    }
}

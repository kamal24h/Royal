using Abp.AutoMapper;
using RoyalEstate.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RoyalEstate.Estates.Dto
{
    [AutoMapFrom(typeof(ServiceType))]
    public class CreateEstateCategoryDto
    {
        [Required(ErrorMessage = "Required")]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}

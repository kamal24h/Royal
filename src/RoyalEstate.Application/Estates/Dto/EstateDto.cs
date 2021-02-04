using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using RoyalEstate.Entities;

namespace RoyalEstate.Estates.Dto
{
    [AutoMapFrom(typeof(Estate))]
    public class EstateDto : AuditedEntityDto<long>
    {
    }
}

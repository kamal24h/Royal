using RoyalEstate.Estates.Dto;
using System.Collections.Generic;
using Abp.AutoMapper;
using RoyalEstate.Entities;

namespace RoyalEstate.EstateServiceTypes.Dto
{
    [AutoMapFrom(typeof(ServiceType))]
    public class ServiceTypeDto
    {
        public ServiceTypeDto()
        {
            EstateTypes = new List<EstateTypeDto>();
        }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public List<EstateTypeDto> EstateTypes { get; set; }
    }
}

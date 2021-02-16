using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using RoyalEstate.EstateServiceTypes.Dto;

namespace RoyalEstate.EstateServiceTypes
{
    public interface ICategoryAppService : IApplicationService
    {
        public Task<List<ServiceTypeDto>> GetServiceTypes();
    }
}

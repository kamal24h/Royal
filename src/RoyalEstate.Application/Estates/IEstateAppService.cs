using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using RoyalEstate.Entities;
using RoyalEstate.Estates.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoyalEstate.Estates
{
    interface IEstateAppService : IApplicationService
    {

        //public List<string> GetAllNames();
        public List<EstateType> GetAllNames();
        void CreateEstateType(CreateEstateTypeInput input);
    }
}

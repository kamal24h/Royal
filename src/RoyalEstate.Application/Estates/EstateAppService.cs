using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using AutoMapper;
using RoyalEstate.Entities;
using RoyalEstate.Estates.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RoyalEstate.Estates
{

    class EstateAppService : AsyncCrudAppService<EstateType, EstateTypeDto> , IEstateAppService
    {
        public EstateAppService(IRepository<EstateType> repository)
            : base(repository)
        {

        }

        public Task<List<EstateTypeDto>> GetAll()
        {
            //throw new NotImplementedException();
        }
     }
}

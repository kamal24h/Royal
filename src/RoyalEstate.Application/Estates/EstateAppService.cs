using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using RoyalEstate.Entities;
using RoyalEstate.Estates.Dto;

namespace RoyalEstate.Estates
{
    public class EstateAppService : AsyncCrudAppService<Estate, EstateDto, long, GetAllEstatesInputDto, CreateEstateDto, EstateDto>, IEstateAppService
    {
        public EstateAppService(IRepository<Estate, long> repository) : base(repository)
        {
            
        }
    }
}

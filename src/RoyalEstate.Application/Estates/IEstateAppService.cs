using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services;
using RoyalEstate.Estates.Dto;

namespace RoyalEstate.Estates
{
    public interface IEstateAppService : IAsyncCrudAppService<EstateDto, long, GetAllEstatesInputDto, CreateEstateDto, EditEstateDto>
    {
        
    }
}

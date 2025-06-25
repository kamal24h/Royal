using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using RoyalEstate.Estates.Dto;

namespace RoyalEstate.Estates
{
    public interface IEstateAppService : IAsyncCrudAppService<EstateDto, long, GetAllEstatesInputDto, CreateEstateDto, EstateDto>
    {
        Task<List<EstateDto>> GetAllWithoutPagingAsync(GetAllEstatesInputDto input);
        //Task<bool> UpdateWithTimeResetAsync(EstateDto inputDto);
    }
}

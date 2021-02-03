using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RoyalEstate.Estates.Dto;

namespace RoyalEstate.Estates
{
    public interface IEstateTypeAppService : IAsyncCrudAppService<EstateTypeDto, int, PagedEstateTypeResultRequestDto, CreateEstateTypeDto, EstateTypeDto>
    {
        Task<ListResultDto<EstateTypeDto>> GetEstateTypeNames();        
    }
            
    //void CreateEstateType(CreateEstateTypeInput input);
}

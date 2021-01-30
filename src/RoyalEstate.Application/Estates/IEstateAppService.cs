using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using RoyalEstate.Estates.Dto;

namespace RoyalEstate.Estates
{
    public interface IEstateAppService : IAsyncCrudAppService<EstateTypeDto, int, PagedEstateTypeResultRequestDto, CreateEntityTypeDto, EstateTypeDto>
    {
        Task<ListResultDto<EstateTypeDto>> GetEstateTypeNames();        
    }
            
    //void CreateEstateType(CreateEstateTypeInput input);
}

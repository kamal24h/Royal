using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using RoyalEstate.Entities;
using RoyalEstate.Estates.Dto;

namespace RoyalEstate.Estates
{

    public class EstateAppService : AsyncCrudAppService<EstateType, EstateTypeDto, int, PagedEstateTypeResultRequestDto, CreateEstateTypeDto, EstateTypeDto>, IEstateAppService
    {
        private readonly IRepository<EstateType> _estateTypeRepository;

        public EstateAppService(IRepository<EstateType> estateTyperepository)
            : base(estateTyperepository)
        {
            _estateTypeRepository = estateTyperepository;
        }
        
        public async Task<ListResultDto<EstateTypeDto>> GetEstateTypeNames()
        {
            var eNames = await _estateTypeRepository.GetAllListAsync();
            return new ListResultDto<EstateTypeDto>(ObjectMapper.Map<List<EstateTypeDto>>(eNames));
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RoyalEstate.Entities;
using RoyalEstate.Estates.Dto;

namespace RoyalEstate.Estates
{

    public class EstateTypeAppService : AsyncCrudAppService<EstateType, EstateTypeDto, int, PagedEstateTypeResultRequestDto, CreateEstateTypeDto, EstateTypeDto>, IEstateTypeAppService
    {
        private readonly IRepository<EstateType> _estateTypeRepository;

        public EstateTypeAppService(IRepository<EstateType> estateTyperepository)
            : base(estateTyperepository)
        {
            _estateTypeRepository = estateTyperepository;
        }
        
        public async Task<ListResultDto<EstateTypeDto>> GetEstateTypeNames()
        {
            var eNames = await _estateTypeRepository.GetAllListAsync();
            return new ListResultDto<EstateTypeDto>(ObjectMapper.Map<List<EstateTypeDto>>(eNames));
        }

        //public override async Task<EstateTypeEditDto> UpdateAsync(EstateTypeEditDto input)
        //{
            
        //    var estateType = _estateTypeRepository.Get(input.Id);

        //    MapToEntity(input, estateType);

        //    await _estateTypeRepository.UpdateAsync(estateType);            

        //    return await GetAsync(input);
        //}

        //public override async Task DeleteAsync(EntityDto<long> input)
        //{
        //    var user = await _userManager.GetUserByIdAsync(input.Id);
        //    await _userManager.DeleteAsync(user);
        //}

        //protected virtual void CheckErrors(IdentityResult identityResult)
        //{
        //    identityResult.CheckErrors(LocalizationManager);
        //}

        //protected override EstateType MapToEntity(CreateEstateTypeDto createInput)
        //{
        //    var estateType = ObjectMapper.Map<EstateType>(createInput);
        //    estateType.SetNormalizedNames();
        //    return estateType;
        //}

    }
}

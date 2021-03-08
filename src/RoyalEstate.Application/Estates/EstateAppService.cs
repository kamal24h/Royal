using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Microsoft.EntityFrameworkCore;
using RoyalEstate.Entities;
using RoyalEstate.Estates.Dto;

namespace RoyalEstate.Estates
{
    public class EstateAppService : AsyncCrudAppService<Estate, EstateDto, long, GetAllEstatesInputDto, CreateEstateDto, EstateDto>, IEstateAppService
    {
        public EstateAppService(IRepository<Estate, long> repository) : base(repository)
        {
            
        }

        public async Task<List<EstateDto>> GetAllWithoutPagingAsync(GetAllEstatesInputDto input)
        {
            var q = await CreateFilteredQuery(input).ToListAsync();
            return q.Select(e => ObjectMapper.Map<EstateDto>(e)).ToList();
        }        

        protected override IQueryable<Estate> CreateFilteredQuery(GetAllEstatesInputDto input)
        {
            return Repository.GetAllIncluding(e => e.Images)
                .WhereIf(input.IsActive == true, e => e.IsActive)
                .WhereIf(!string.IsNullOrEmpty(input.Term), e => e.Title.Contains(input.Term) || e.Description.Contains(input.Term))
                .WhereIf(input.EstateTypeId != null, e => e.EstateTypeId == input.EstateTypeId)
                .WhereIf(input.CityId != null, e => e.CityId == input.CityId)
                .WhereIf(input.DistrictId != null, e => e.DistrictId == input.DistrictId)
                .WhereIf(input.MinArea != null, e => e.Area >= input.MinArea)
                .WhereIf(input.MaxArea != null, e => e.Area <= input.MaxArea)
                .WhereIf(input.MinPrice != null, e => e.Price >= input.MinPrice)
                .WhereIf(input.MaxPrice != null, e => e.Price <= input.MaxPrice)
                .WhereIf(input.MinRent != null, e => e.Rent >= input.MinRent)
                .WhereIf(input.MaxRent != null, e => e.Rent <= input.MaxRent)
                .WhereIf(input.MinDeposit != null, e => e.Deposit >= input.MinDeposit)
                .WhereIf(input.MaxDeposit != null, e => e.Deposit <= input.MaxDeposit)
                .WhereIf(input.Rooms != null, e => e.Rooms == input.Rooms)
                .WhereIf(input.Floor != null, e => e.Floor == input.Floor)
                .WhereIf(input.Elevator, e => e.Elevator == true)
                .WhereIf(input.Parking, e => e.Parking == true)
                .WhereIf(input.CustomerId != null, e => e.CustomerId == input.CustomerId);
        }

        protected override Task<Estate> GetEntityByIdAsync(long id)
        {
            var entity = Repository.GetAllIncluding(p => p.Images, p => p.District, p => p.City, p => p.Customer, e => e.CreatorUser).FirstOrDefault(p => p.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(Estate), id);
            }

            var taskSrc = new TaskCompletionSource<Estate>();
            taskSrc.SetResult(entity);
            return taskSrc.Task;
        }
    }
}

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
using RoyalEstate.Entities;
using RoyalEstate.Estates.Dto;

namespace RoyalEstate.Estates
{
    public class EstateAppService : AsyncCrudAppService<Estate, EstateDto, long, GetAllEstatesInputDto, CreateEstateDto, EstateDto>, IEstateAppService
    {
        public EstateAppService(IRepository<Estate, long> repository) : base(repository)
        {
            
        }

        protected override IQueryable<Estate> CreateFilteredQuery(GetAllEstatesInputDto input)
        {
            return Repository.GetAllIncluding(e => e.Images);
        }

        protected override Task<Estate> GetEntityByIdAsync(long id)
        {
            var entity = Repository.GetAllIncluding(p => p.Images, p=>p.Customer).FirstOrDefault(p => p.Id == id);
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

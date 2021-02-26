using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using RoyalEstate.Entities;
using RoyalEstate.Estates.Dto;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RoyalEstate.Estates
{
    public class EstateCategoryAppService : ApplicationService, IEstateCategoryAppService
    {
        private readonly IRepository<ServiceType> _repository;
        public EstateCategoryAppService(IRepository<ServiceType> repository)
        {
            _repository = repository;
        }

        public async Task<List<EstateCategoryDto>> GetAllAsync()
        {
            return await _repository.GetAllIncluding(c => c.EstateTypes).Select(c=>ObjectMapper.Map<EstateCategoryDto>(c)).ToListAsync();
        }
    }
}

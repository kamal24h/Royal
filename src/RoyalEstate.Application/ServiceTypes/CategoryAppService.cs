using Abp.Application.Services;
using Abp.Domain.Repositories;
using RoyalEstate.Entities;
using RoyalEstate.EstateServiceTypes;
using RoyalEstate.EstateServiceTypes.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoyalEstate.ServiceTypes
{
    public class CategoryAppService : ApplicationService, ICategoryAppService
    {
        private readonly IRepository<ServiceType> _repository;
        public CategoryAppService(IRepository<ServiceType> repository)
        {
            _repository = repository;
        }
        public async Task<List<ServiceTypeDto>> GetServiceTypes()
        {
            return (await _repository.GetAllListAsync()).Select(s => ObjectMapper.Map<ServiceTypeDto>(s)).ToList();
        }
    }
}

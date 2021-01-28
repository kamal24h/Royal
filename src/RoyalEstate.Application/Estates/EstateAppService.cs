using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using RoyalEstate.Entities;
using RoyalEstate.Estates.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RoyalEstate.Estates
{

    class EstateAppService :  IEstateAppService
    {
        
        private readonly IRepository<EstateType> _estateTypeRepository;

        public EstateAppService(IRepository<EstateType> estateTypeRepository)
        {
            _estateTypeRepository = estateTypeRepository;
        }

        public void CreateEstateType(CreateEstateTypeInput input)
        {
            var estateType = _estateTypeRepository.FirstOrDefault(p => p.Name == input.Name);
            if (estateType != null)
            {
                throw new UserFriendlyException("نوع ملکی با نام مشابه وجود دارد");
            }

            estateType = new EstateType { 
                Name = input.Name,
                CreationTime = input.CreationTime,
                IsActive = input.IsActive };
            _estateTypeRepository.Insert(estateType); 
        }

        public List<EstateType> GetAllNames()
        {
            var estateType = _estateTypeRepository.GetAll();

            return (List<EstateType>)estateType;
                
        }
    }
}

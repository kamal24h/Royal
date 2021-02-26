using Abp.Application.Services;
using RoyalEstate.Estates.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RoyalEstate.Estates
{
    public interface IEstateCategoryAppService : IApplicationService
    {
        Task<List<EstateCategoryDto>> GetAllAsync();
    }
}

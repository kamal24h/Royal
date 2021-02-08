using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalEstate.Customers.Dto;

namespace RoyalEstate.Customers
{
    public interface ICustomerAppService : IAsyncCrudAppService<CustomerDto, long, GetAllCustomersInputDto, CreateCustomerDto, CustomerDto>
    {
        Task<List<SelectListItem>> GetCustomersSelectListAsync();
    }
}

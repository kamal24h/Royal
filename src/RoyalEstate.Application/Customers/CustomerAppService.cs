using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalEstate.Customers.Dto;
using RoyalEstate.Entities;

namespace RoyalEstate.Customers
{
    public class CustomerAppService : AsyncCrudAppService<Customer, CustomerDto, long, GetAllCustomersInputDto, CreateCustomerDto, CustomerDto>, ICustomerAppService
    {
        public CustomerAppService(IRepository<Customer, long> repository) : base(repository)
        {
        }

        public async Task<List<SelectListItem>> GetCustomersSelectListAsync()
        {
            return (await Repository.GetAllListAsync()).Select(c => new SelectListItem {Text = c.Name, Value = c.Id.ToString()}).ToList();
        }
    }
}

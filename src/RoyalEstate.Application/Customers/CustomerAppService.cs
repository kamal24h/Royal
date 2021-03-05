using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
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
            return (await Repository.GetAllListAsync()).Select(c => new SelectListItem {Text = $"{c.Name} {c.Surname}", Value = c.Id.ToString()}).ToList();
            
        }

        protected override IQueryable<Customer> CreateFilteredQuery(GetAllCustomersInputDto input)
        {
            return Repository.GetAllIncluding(c => c.City)
                .WhereIf(input.IsActive != null, c => c.IsActive == input.IsActive)
                .WhereIf(!string.IsNullOrEmpty(input.Term), c=>c.Name.Contains(input.Term)||c.Surname.Contains(input.Term));
        }

        protected override Task<Customer> GetEntityByIdAsync(long id)
        {
            var entity = Repository.GetAllIncluding(e => e.City).FirstOrDefault(e => e.Id == id);
            if (entity == null)
            {
                throw new EntityNotFoundException(typeof(Customer), id);
            }

            var taskSrc = new TaskCompletionSource<Customer>();
            taskSrc.SetResult(entity);
            return taskSrc.Task;
        }

        public override async Task DeleteAsync(EntityDto<long> input)
        {
            var customer = await Repository.GetAsync(input.Id);
            customer.IsActive = false;            
            await Repository.UpdateAsync(customer);
        }        
    }
}

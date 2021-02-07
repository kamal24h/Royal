using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using RoyalEstate.Entities;

namespace RoyalEstate.Customers.Dto
{
    public class CustomerMapProfile : Profile
    {
        public CustomerMapProfile()
        {
            CreateMap<CustomerDto, Customer>().ForMember(d => d.CreationTime, opt => opt.Ignore());
        }
    }
}

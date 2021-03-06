﻿using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using Abp.Timing;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using RoyalEstate.Entities;

namespace RoyalEstate.Customers.Dto
{
    [AutoMapTo(typeof(Customer))]
    public class CreateCustomerDto 
    {
        public CreateCustomerDto()
        {
            Cities = new List<SelectListItem>();
        }

        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxSurnameLength)]
        public string Surname { get; set; }

        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string EmailAddress { get; set; }

        [Phone]
        [StringLength(AbpUserBase.MaxPhoneNumberLength)]
        public string CellPhone1 { get; set; }

        public string CellPhone2 { get; set; }

        [Phone]
        [StringLength(AbpUserBase.MaxPhoneNumberLength)]
        public string PhoneNumber1 { get; set; }

        public string PhoneNumber2 { get; set; }

        [Required]
        public int CityId { get; set; }
        
        [Required]
        public string Address { get; set; }
        
        public bool IsActive { get; set; }

        public bool IsSeller { get; set; }

        public bool IsBuyer { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public List<SelectListItem> Cities { get; set; }
    }
}

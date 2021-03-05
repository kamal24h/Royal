using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Timing;
using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using Abp.AutoMapper;
using RoyalEstate.Entities;

namespace RoyalEstate.Customers.Dto
{
    [AutoMapFrom(typeof(Customer))]
    public class CustomerDto : AuditedEntityDto<long>
    {
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
        public string Address { get; set; }

        [DisableDateTimeNormalization]
        public DateTime CreationTime { get; set; }

        public long CityId { get; set; }
        public string CityName { get; set; }

        [DisplayName("")]
        public bool IsActive { get; set; }

        public bool IsSeller { get; set; }

        public bool IsBuyer { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
    }
}

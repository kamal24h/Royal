﻿using Abp.Authorization.Users;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RoyalEstate.Entities
{
    public class Customer : AuditedEntity<long>
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

        [Phone]
        [StringLength(AbpUserBase.MaxPhoneNumberLength)]
        public string CellPhone2 { get; set; }

        [Phone]
        [StringLength(AbpUserBase.MaxPhoneNumberLength)]
        public string PhoneNumber1 { get; set; }

        [Phone]
        [StringLength(AbpUserBase.MaxPhoneNumberLength)]
        public string PhoneNumber2 { get; set; }
                
        [StringLength(200)]
        public string Address { get; set; }

        public bool IsActive { get; set; }

        public bool IsSeller { get; set; }

        public bool IsBuyer { get; set; }

        public virtual ICollection<Estate> Estates { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }
    }
}
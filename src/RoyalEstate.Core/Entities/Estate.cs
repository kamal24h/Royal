﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using RoyalEstate.Authorization.Users;

namespace RoyalEstate.Entities
{
    [Table("Estates")]
    public class Estate : AuditedEntity<long>
    {
        [Required]
        [MinLength(10)]
        public string Title { get; set; }

        [Required]
        [ForeignKey(nameof(CreatorUserId))]
        public User CreatorUser { get; set; }

        [ForeignKey(nameof(LastModifierUserId))]
        public User LastModifierUser { get; set; }

        [ForeignKey(nameof(EstateTypeId))]
        public EstateType EstateType { get; set; }
        public int EstateTypeId { get; set; }

        [ForeignKey(nameof(ServiceTypeId))]
        public ServiceType ServiceType { get; set; }
        public int ServiceTypeId { get; set; }

        public double Area { get; set; }
        public int? Rooms { get; set; }
        public int? Floor { get; set; }
        public int? TotalFloors { get; set; }
        public int? UnitsPerFloor { get; set; }
        public bool? Parking { get; set; }
        public bool? StoreRoom { get; set; }
        public DateTime BuiltDate { get; set; }

        
        public long? Price { get; set; }
        public long? Rent { get; set; }
        public long? Deposit { get; set; }

        [Required]
        public string District { get; set; }

        public DateTime CreationTime { get; set; }
        
        public DateTime? LastModificationTime { get; set; }        

        [ForeignKey(nameof(CityId))]
        public City City { get; set; }
        public int CityId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        public long CustomerId { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Address { get; set; }
        
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }

            LastModificationTime = DateTime.Now;
        }

        public bool IsActive { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }
        
        public virtual ICollection<EstateImage> Images { get; set; }
    }
}
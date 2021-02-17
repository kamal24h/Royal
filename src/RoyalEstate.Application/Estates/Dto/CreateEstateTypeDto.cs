using Abp.AutoMapper;
using Abp.Runtime.Validation;
using RoyalEstate.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RoyalEstate.Estates.Dto
{
    [AutoMapTo(typeof(EstateType))]
    public class CreateEstateTypeDto
    {
        public const int MaxNameLength = 100;

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        public DateTime CreationTime { get; set; }

        public bool IsActive { get; set; }

        public int ServiceTypeId { get; set; }

        public bool Price { get; set; }
        public bool Rent { get; set; }
        public bool Deposit { get; set; }

        public bool Area { get; set; }
        public bool Rooms { get; set; }
        public bool Floor { get; set; }
        public bool TotalFloors { get; set; }
        public bool UnitsPerFloor { get; set; }
        public bool Parking { get; set; }
        public bool Storeroom { get; set; }
        public bool Elevator { get; set; }
        public bool BuiltDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;


namespace RoyalEstate.Entities{
    
    public class EstateType : Entity, IHasCreationTime
    {
        public const int MaxNameLength = 256;

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        public DateTime CreationTime { get; set; }

        public bool IsActive { get; set; }

        public EstateType()
        {
            CreationTime = DateTime.Now;
        }

        public static implicit operator List<object>(EstateType v)
        {
            throw new NotImplementedException();
        }
    }
}
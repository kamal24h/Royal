using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace RoyalEstate.Entities
{
    public class Estate : Entity, IHasCreationTime, IHasModificationTime
    {

        public int PersonId { get; set; }

        public Person person { get; set; }

        public int EstateTypeId { get; set; }

        [Required]        
        public string City { get; set; }

        [Required]
        public string District { get; set; }

        public DateTime CreationTime { get; set; }
        
        public DateTime? LastModificationTime { get; set; }        

        public bool IsActive { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }
        
        
        public Estate()
        {
            CreationTime = DateTime.Now;

            LastModificationTime = DateTime.Now;
        }


        
    }
}

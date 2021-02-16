using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace RoyalEstate.Entities
{
    public class ServiceType: Entity
    {
        public ServiceType()
        {
            EstateTypes = new HashSet<EstateType>();
        }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public ICollection<EstateType> EstateTypes { get; set; }
    }
}

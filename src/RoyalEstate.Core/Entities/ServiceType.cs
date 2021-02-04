using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;

namespace RoyalEstate.Entities
{
    public class ServiceType: Entity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}

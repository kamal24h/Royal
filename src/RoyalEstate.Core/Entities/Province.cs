using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace RoyalEstate.Entities
{
    [Table("Provinces")]
    public class Province : Entity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}

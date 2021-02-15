using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RoyalEstate.Entities
{

    [Table("District")]
    public class District : Entity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey(nameof(CityId))]
        public virtual City City { get; set; }

        [Required]
        public int CityId { get; set; }

        public bool IsActive { get; set; }
    }

}

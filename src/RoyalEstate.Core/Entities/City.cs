using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace RoyalEstate.Entities
{
    [Table("Cities")]
    public class City : Entity
    {
        [MaxLength(100)]
        public string Name { get; set; }

        [ForeignKey(nameof(ProvinceId))]
        public Province Province { get; set; }
        [Required]
        public int ProvinceId { get; set; }

        public bool IsActive { get; set; }
    }
}

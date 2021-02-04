using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Domain.Entities;

namespace RoyalEstate.Entities
{
    public class EstateImage:Entity<long>
    {
        [Required]
        [ForeignKey(nameof(EstateId))]
        public Estate Estate { get; set; }
        public long EstateId { get; set; }

        public string Path { get; set; }
    }
}

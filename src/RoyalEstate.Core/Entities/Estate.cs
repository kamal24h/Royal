using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Abp.Timing;
using RoyalEstate.Authorization.Users;
using System.ComponentModel;

namespace RoyalEstate.Entities
{
    [Table("Estates")]
    public class Estate : AuditedEntity<long>
    {
        public Estate()
        {
            Images = new HashSet<EstateImage>();
        }
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

        public string FilingCode { get; set; }

        public double Area { get; set; }
        public int? Rooms { get; set; }
        public int? Floor { get; set; }
        public int? TotalFloors { get; set; }
        public int? UnitsPerFloor { get; set; }
        public bool? Parking { get; set; }
        public bool? StoreRoom { get; set; }
        public bool? Elevator { get; set; }
        public bool? MasterRoom { get; set; }
        public string LegalDoc { get; set; }
        
        public DateTime BuiltDate { get; set; }
        public long? BuildYear { get; set; }


        public long? Price { get; set; }
        public long? Rent { get; set; }
        public long? Deposit { get; set; }


        [ForeignKey(nameof(CityId))]
        [Required]
        public City City { get; set; }
        public int CityId { get; set; }


        [ForeignKey(nameof(DistrictId))]
        public District District { get; set; }
        public int? DistrictId { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; }
        public long CustomerId { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Address { get; set; }
        
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }
        
        public DateTime OrderDate { get; set; }

        [StringLength(2000)]
        public string Description { get; set; }
        
        public ICollection<EstateImage> Images { get; set; }
    }
}

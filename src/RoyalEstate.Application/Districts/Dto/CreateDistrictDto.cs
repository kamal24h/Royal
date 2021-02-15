using System.ComponentModel.DataAnnotations;
using RoyalEstate.Entities;
using Abp.AutoMapper;

namespace RoyalEstate.Districts.Dto
{
    [AutoMapTo(typeof(District))]
    public class CreateDistrictDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int CityId { get; set; }

        public bool IsActive { get; set; }
    }
}

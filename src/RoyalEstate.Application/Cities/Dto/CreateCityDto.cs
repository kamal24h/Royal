using System.ComponentModel.DataAnnotations;
using RoyalEstate.Entities;
using Abp.AutoMapper;

namespace RoyalEstate.Cities.Dto
{
    [AutoMapTo(typeof(City))]
    public class CreateCityDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int ProvinceId { get; set; }

        public bool IsActive { get; set; }
    }
}

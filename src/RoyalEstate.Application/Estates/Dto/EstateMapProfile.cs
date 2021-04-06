using AutoMapper;
using RoyalEstate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RoyalEstate.Estates.Dto
{
    public class EstateMapProfile : Profile
    {
        public EstateMapProfile()
        {
            CreateMap<EstateDto, Estate>();
            CreateMap<EstateDto, Estate>()
                .ForMember(d => d.Images, opt => opt.Ignore())
                .ForMember(d => d.CreationTime, opt => opt.Ignore())
                .ForMember(d => d.CreatorUserId, opt => opt.Ignore())
                .AfterMap(UpdateImages);
        }

        private void UpdateImages(EstateDto dto, Estate estate)
        {
            estate.Images.Where(i => !dto.ImagePaths.Any(p => p.Equals(i.Path)))
                .ToList().ForEach(deleted => estate.Images.Remove(deleted));

            dto.ImagePaths.Where(p => !estate.Images.Any(i => i.Path.Equals(p))).ToList()
                .ForEach(p => estate.Images.Add(new EstateImage { EstateId = dto.Id, Path = p }));
        }
    }
}

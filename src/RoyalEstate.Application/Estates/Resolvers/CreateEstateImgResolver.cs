using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using RoyalEstate.Entities;
using RoyalEstate.Estates.Dto;

namespace RoyalEstate.Estates.Resolvers
{
    public class CreateEstateImgResolver : IValueResolver<CreateEstateDto, Estate, ICollection<EstateImage>>
    {
        public ICollection<EstateImage> Resolve(CreateEstateDto source, Estate destination, ICollection<EstateImage> destMember, ResolutionContext context)
        {
            ICollection<EstateImage> images = new List<EstateImage>();
            foreach (string imagePath in source.ImagePaths)
            {
                images.Add(new EstateImage{Path = imagePath});
            }

            return images;
        }
    }
}

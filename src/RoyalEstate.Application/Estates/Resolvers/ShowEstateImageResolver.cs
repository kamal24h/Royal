using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using RoyalEstate.Entities;
using RoyalEstate.Estates.Dto;

namespace RoyalEstate.Estates.Resolvers
{
    public class ShowEstateImageResolver : IValueResolver<Estate, EstateDto, List<string>>
    {
        public List<string> Resolve(Estate source, EstateDto destination, List<string> destMember, ResolutionContext context)
        {
            List<string> paths = new List<string>();
            foreach (EstateImage image in source.Images)
            {
                paths.Add(image.Path);
            }

            return paths;
        }
    }
}

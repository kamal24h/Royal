﻿using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using RoyalEstate.Authorization;
using RoyalEstate.Entities;
using RoyalEstate.Estates.Dto;
using RoyalEstate.Estates.Resolvers;

namespace RoyalEstate
{
    [DependsOn(
        typeof(RoyalEstateCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class RoyalEstateApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<RoyalEstateAuthorizationProvider>();

            Configuration.Modules.AbpAutoMapper().Configurators.Add(config =>
                {
                    config.CreateMap<EstateTypeDto, EstateType>()
                        .ForMember(d => d.CreationTime, options => options.Ignore());

                    config.CreateMap<CreateEstateDto, Estate>().ForMember(d => d.Images,
                        options => options.MapFrom<CreateEstateImgResolver>());                   

                    config.CreateMap<Estate, EstateDto>()
                        .ForMember(d => d.ImagePaths, opt => opt.MapFrom<ShowEstateImageResolver>());
                    
                });
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(RoyalEstateApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}

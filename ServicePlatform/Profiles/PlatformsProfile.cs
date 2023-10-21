using AutoMapper;
using MicroservicePlatform.Dtos;
using MicroservicePlatform.Model;

namespace MicroservicePlatform.Profiles{
    public class PlatformsProfile:Profile
    {
        public PlatformsProfile()
        {
            CreateMap<Platform,PlatformReadDto>();
            CreateMap<PlatformCreateDto,Platform>();
        }
    }
}
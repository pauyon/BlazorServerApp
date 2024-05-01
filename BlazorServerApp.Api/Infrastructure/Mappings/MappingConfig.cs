using AutoMapper;
using BlazorServerApp.Shared.Domain.Dtos;
using BlazorServerApp.Shared.Domain.Entities;

namespace BlazorServerApp.Api.Infrastructure.Mappings
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Camera, CameraDto>().ReverseMap();
            CreateMap<Accessory, AccessoryDto>().ReverseMap();
        }
    }
}

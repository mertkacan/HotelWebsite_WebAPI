using AutoMapper;
using Hotel.EntityLayer.Concrete;
using Hotel.WebUI.Dtos.AppUserDto;
using Hotel.WebUI.Dtos.LoginDto;
using Hotel.WebUI.Dtos.ServiceDto;

namespace Hotel.WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();

            CreateMap<AppUser,CreateNewUserDto>().ReverseMap();
            CreateMap<AppUser,LoginUserDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using SolarDR.Application;
using SolarDR.MVC.Models.ImageModel;
using SolarDR.MVC.Models.PersonModel;

namespace SolarDR.MVC.Mapper
{
    public class MVCMapperProfile : Profile
    {
        public MVCMapperProfile()
        {
            CreateMap<PersonDTO, PersonResponse>();
            CreateMap<ImageDto, ImageSimpleModel>();
        }
    }
}
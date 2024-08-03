
using AutoMapper;
using SolarDR.Domain;

namespace SolarDR.Application.Mapper
{
    public class ApplicationMapperProfile : Profile
    {
        public ApplicationMapperProfile()
        {
            CreateMap<PersonDTO, Person>()
                .ReverseMap(); 
            CreateMap<ImageDto, Image>()
                .ReverseMap();
        }
    }
}

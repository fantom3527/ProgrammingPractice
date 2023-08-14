using AutoMapper;
using PeoplesCities.Application.Common.Mapping;
using PeoplesCities.Application.Features.Cities.Command.CreateCity;

namespace PeoplesCities.WebApi.Models
{
    public class CityDto : IMapWith<CreateCityCommand>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CityDto, CreateCityCommand>()
                .ForPath(cityCommand => cityCommand.City.Name,
                    opt => opt.MapFrom(cityDto => cityDto.Name))
                .ForPath(cityCommand => cityCommand.City.Description,
                    opt => opt.MapFrom(cityDto => cityDto.Description));
        }
    }
}

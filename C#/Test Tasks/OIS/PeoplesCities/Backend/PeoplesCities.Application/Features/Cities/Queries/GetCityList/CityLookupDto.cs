﻿using AutoMapper;
using PeoplesCities.Application.Common.Mapping;
using PeoplesCities.Domain;

namespace PeoplesCities.Application.Features.Cities.Queries.GetCityList
{
    public class CityLookupDto : IMapWith<City>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<City, CityLookupDto>()
                .ForMember(cityVm => cityVm.Id,
                    opt => opt.MapFrom(city => city.Id))
                .ForMember(cityVm => cityVm.Name,
                    opt => opt.MapFrom(city => city.Name))
                .ForMember(cityVm => cityVm.Description,
                    opt => opt.MapFrom(city => city.Description));
        }
    }
}

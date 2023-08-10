using AutoMapper;
using PeoplesCities.Application.Common.Mapping;
using PeoplesCities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplesCities.Application.Features.Users.Queries
{
    public class UserDetailsVm : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // Создает соответсвие между классом User и UserDetailsVm
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsVm>()
                .ForMember(noteVm => noteVm.Id,
                    opt => opt.MapFrom(note => note.Id))
                .ForMember(noteVm => noteVm.Name,
                    opt => opt.MapFrom(note => note.Name))
                .ForMember(noteVm => noteVm.Email,
                    opt => opt.MapFrom(note => note.Email));
        }
    }
}

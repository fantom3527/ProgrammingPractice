using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeoplesCities.Domain;
using System.Threading.Tasks;

namespace PeoplesCities.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public User User { get; set; }
    }
}

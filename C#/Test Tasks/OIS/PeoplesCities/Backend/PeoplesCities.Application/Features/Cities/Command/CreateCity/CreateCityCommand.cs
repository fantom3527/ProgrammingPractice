using MediatR;
using PeoplesCities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplesCities.Application.Features.Cities.Command.CreateCity
{
    public class CreateCityCommand : IRequest<Guid>
    {
        public City City { get; set; }
    }
}

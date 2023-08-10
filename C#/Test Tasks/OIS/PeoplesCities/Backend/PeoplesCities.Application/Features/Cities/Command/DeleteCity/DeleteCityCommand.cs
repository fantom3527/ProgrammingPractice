using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplesCities.Application.Features.Cities.Command.DeleteCity
{
    public class DeleteCityCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}

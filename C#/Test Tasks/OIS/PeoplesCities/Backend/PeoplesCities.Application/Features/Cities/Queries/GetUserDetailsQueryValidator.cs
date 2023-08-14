﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplesCities.Application.Features.Cities.Queries
{
    public class GetUserDetailsQueryValidator : AbstractValidator<GetCityDetailsQuery>
    {
        public GetUserDetailsQueryValidator()
        {
            RuleFor(createNoteCommand => createNoteCommand.Id).NotEqual(Guid.Empty);
        }
    }
}

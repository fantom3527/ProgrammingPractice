﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplesCities.Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(createNoteCommand => createNoteCommand.User.Id).NotEqual(Guid.Empty);
            RuleFor(createNoteCommand => createNoteCommand.User.CityId).NotEqual(Guid.Empty);
            RuleFor(createNoteCommand => createNoteCommand.User.Name).NotEmpty().MaximumLength(250);
            RuleFor(createNoteCommand => createNoteCommand.User.Email).NotEmpty().MaximumLength(250);
        }
    }
}

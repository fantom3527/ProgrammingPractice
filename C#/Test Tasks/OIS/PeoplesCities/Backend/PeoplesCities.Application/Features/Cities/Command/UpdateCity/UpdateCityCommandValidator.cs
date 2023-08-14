using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplesCities.Application.Features.Cities.Command.UpdateCity
{
    public class UpdateCityCommandValidator : AbstractValidator<UpdateCityCommand>
    {
        public UpdateCityCommandValidator()
        {
            RuleFor(createNoteCommand => createNoteCommand.City.Id).NotEqual(Guid.Empty);
            RuleFor(createNoteCommand => createNoteCommand.City.Name).NotEmpty().MaximumLength(250);
            RuleFor(createNoteCommand => createNoteCommand.City.Description).NotEmpty().MaximumLength(250);
        }
    }
}

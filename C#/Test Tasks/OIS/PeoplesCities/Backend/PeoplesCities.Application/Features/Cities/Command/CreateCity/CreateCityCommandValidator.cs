using FluentValidation;

namespace PeoplesCities.Application.Features.Cities.Command.CreateCity
{
    public class CreateCityCommandValidator : AbstractValidator<CreateCityCommand>
    {
        public CreateCityCommandValidator()
        {
            RuleFor(createCityCommand => createCityCommand.City.Name).NotEmpty().MaximumLength(250);
            RuleFor(createCityCommand => createCityCommand.City.Description).NotEmpty().MaximumLength(250);
        }
    }
}

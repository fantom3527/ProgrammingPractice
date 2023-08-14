using FluentValidation;

namespace PeoplesCities.Application.Features.Cities.Queries
{
    public class GetUserDetailsQueryValidator : AbstractValidator<GetCityDetailsQuery>
    {
        public GetUserDetailsQueryValidator()
        {
            RuleFor(createUserCommand => createUserCommand.Id).NotEqual(Guid.Empty);
        }
    }
}

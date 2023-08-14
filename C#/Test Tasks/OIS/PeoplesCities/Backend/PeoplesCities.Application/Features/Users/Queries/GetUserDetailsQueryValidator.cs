using FluentValidation;

namespace PeoplesCities.Application.Features.Users.Queries
{
    public class GetUserDetailsQueryValidator : AbstractValidator<GetUserDetailsQuery>
    {
        public GetUserDetailsQueryValidator()
        {
            RuleFor(createUserCommand => createUserCommand.Id).NotEqual(Guid.Empty);
        }
    }
}

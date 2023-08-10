using MediatR;
using PeoplesCities.Application.Interfaces;
using PeoplesCities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplesCities.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUsersDbContext _dbContext;

        public CreateUserCommandHandler(IUsersDbContext dbContext) => 
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateUserCommand requst, CancellationToken cancellationToken)
        {
            var user = new User()
            {
                Id = requst.User.Id,
                Name = requst.User.Name,
                Email = requst.User.Email,
            };

            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return user.Id;
        }
    }
}

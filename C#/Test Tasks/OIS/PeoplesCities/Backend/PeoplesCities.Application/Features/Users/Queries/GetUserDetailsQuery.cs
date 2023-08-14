﻿using MediatR;

namespace PeoplesCities.Application.Features.Users.Queries
{
    public class GetUserDetailsQuery : IRequest<UserDetailsVm>
    {
        public Guid Id { get; set; }
    }
}

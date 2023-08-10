﻿using MediatR;
using PeoplesCities.Application.Features.Users.Commands.CreateUser;
using PeoplesCities.Application.Interfaces;
using PeoplesCities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeoplesCities.Application.Features.Cities.Command.CreateCity
{
    internal class CreateCityCommandHandler : IRequestHandler<CreateCityCommand, Guid>
    {
        private readonly ICitiesDbContext _dbContext;

        public CreateCityCommandHandler(ICitiesDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateCityCommand requst, CancellationToken cancellationToken)
        {
            var city = new City()
            {
                Id = requst.City.Id,
                Name = requst.City.Name,
                Description = requst.City.Description,
            };

            await _dbContext.Cities.AddAsync(city, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return city.Id;
        }
    }
}

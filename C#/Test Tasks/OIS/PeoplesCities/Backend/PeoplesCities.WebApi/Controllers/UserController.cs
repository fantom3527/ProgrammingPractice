using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeoplesCities.Application.Features.Users.Commands.CreateUser;
using PeoplesCities.Application.Features.Users.Commands.DeleteUser;
using PeoplesCities.Application.Features.Users.Commands.UpdateUser;
using PeoplesCities.Application.Features.Users.Queries;
using PeoplesCities.Domain;

namespace PeoplesCities.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper) => _mapper = mapper;

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetailsVm>> Get(Guid id)
        {
            var query = new GetUserDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] User user)
        {
            var command = _mapper.Map<CreateUserCommand>(user);
            var userId = await Mediator.Send(command);

            return Ok(userId);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] User user)
        {
            var command = _mapper.Map<UpdateUserCommand>(user);
            await Mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteUserCommand
            {
                Id = id,
            };
            await Mediator.Send(command);

            return NoContent();
        }

    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeoplesCities.Application.Features.Users.Commands.CreateUser;
using PeoplesCities.Application.Features.Users.Commands.DeleteUser;
using PeoplesCities.Application.Features.Users.Commands.UpdateUser;
using PeoplesCities.Application.Features.Users.Queries;
using PeoplesCities.Domain;
using PeoplesCities.WebApi.Models;

namespace PeoplesCities.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;

        public UserController(IMapper mapper) => _mapper = mapper;


        /// <summary>
        /// Gets user by id.
        /// </summary>
        /// <param name="id">User id (guid).</param>
        /// <remarks>
        /// Sample request:
        /// GET /user/13360799-8908-4449-9CA9-64A3AA5AEA8C
        /// </remarks>
        /// <returns>Returns UserDetailsVm.</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserDetailsVm>> Get(Guid id)
        {
            var query = new GetUserDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /user
        /// {
        ///     cityid: "user's cityid"
        ///     name:   "user name"
        ///     Email:  "user description"
        /// }
        /// </remarks>
        /// <param name="userDto">UserDto object.</param>
        /// <returns>Returns id (guid).</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create([FromBody] UserDto userDto)
        {
            var command = _mapper.Map<CreateUserCommand>(userDto);
            var userId = await Mediator.Send(command);

            return Ok(userId);
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// Sample request:
        /// PUT /user
        /// {
        ///     Id:          "user id"  
        ///     name:        "user name"
        ///     description: "user description"
        /// }
        /// </remarks>
        /// <param name="userDto">UserDto object.</param>
        /// <returns>Return NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Update([FromBody] UserDto userDto)
        {
            var command = _mapper.Map<UpdateUserCommand>(userDto);
            await Mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deletes the user by id.
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /user/88DEB432-062F-43DE-8DCD-8B6EF79073D3
        /// </remarks>
        /// <param name="id">user id (guid).</param>
        /// <returns>Returns NoContent.</returns>
        /// <response code="200">Success</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
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

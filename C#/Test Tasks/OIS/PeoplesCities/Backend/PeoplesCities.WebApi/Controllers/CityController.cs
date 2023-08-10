using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeoplesCities.Application.Features.Cities.Command.CreateCity;
using PeoplesCities.Application.Features.Cities.Command.DeleteCity;
using PeoplesCities.Application.Features.Cities.Command.UpdateCity;
using PeoplesCities.Application.Features.Cities.Queries;
using PeoplesCities.Domain;

namespace PeoplesCities.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CityController : BaseController
    {
        private readonly IMapper _mapper;

        public CityController(IMapper mapper) => _mapper = mapper;

        [HttpGet("{id}")]
        public async Task<ActionResult<CityDetailsVm>> Get(Guid id)
        {
            var query = new GetCityDetailsQuery()
            {
                Id = id
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] City city)
        {
            var command = _mapper.Map<CreateCityCommand>(city);
            var noteId = await Mediator.Send(command);

            return Ok(noteId);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] City city)
        {
            var command = _mapper.Map<UpdateCityCommand>(city);
            await Mediator.Send(command);

            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteCityCommand
            {
                Id = id,
            };
            await Mediator.Send(command);

            return NoContent();
        }

    }
}

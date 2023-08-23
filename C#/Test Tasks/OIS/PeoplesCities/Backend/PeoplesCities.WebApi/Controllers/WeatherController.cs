﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PeoplesCities.Application.Features.Weathers.Queries;

namespace PeoplesCities.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class WeatherController : BaseController
    {
        /// <summary>
        /// Gets weather by id.
        /// </summary>
        /// <param name="cityId">City id (guid).</param>
        /// <remarks>
        /// Sample request:
        /// GET /weather/f278d99c-2876-4bfd-b6b9-1b901bed4267
        /// </remarks>
        /// <returns>Returns WeatherDetailsVm.</returns>
        /// <response code="200">Success</response>
        [HttpGet("{cityId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<WeatherDetailsVm>> GetWeather(Guid cityId)
        {
            var query = new GetWeatherDetails()
            {
                CityId = cityId
            };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
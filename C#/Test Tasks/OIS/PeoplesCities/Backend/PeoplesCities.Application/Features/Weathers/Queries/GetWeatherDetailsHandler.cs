using MediatR;
using Newtonsoft.Json;
using PeoplesCities.Application.Sevices;

namespace PeoplesCities.Application.Features.Weathers.Queries
{
    public class GetWeatherDetailsHandler : IRequestHandler<GetWeatherDetails, WeatherDetailsVm>
    {
        private readonly IWireMockService _wireMockServece;

        public GetWeatherDetailsHandler(IWireMockService wireMockServece)
        {
            _wireMockServece = wireMockServece;
        }

        public async Task<WeatherDetailsVm> Handle(GetWeatherDetails request, CancellationToken cancellationToken)
        {
            //TODO: перенести в 
            var response = await _wireMockServece.GetResponseAsync("/weather/" + request.CityId.ToString());
            var responseBody = await response.Content.ReadAsStringAsync();
            var weather = JsonConvert.DeserializeObject<WeatherDetailsVm>(responseBody);

            return weather;
        }
    }

}
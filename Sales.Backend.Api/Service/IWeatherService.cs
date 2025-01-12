using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stackup.Api.Service
{
    public interface IWeatherService
    {
        public IEnumerable<WeatherForecast> GetWeather();
    }
}
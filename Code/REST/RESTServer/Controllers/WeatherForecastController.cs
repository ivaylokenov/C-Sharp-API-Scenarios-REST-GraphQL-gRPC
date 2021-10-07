namespace RestServer.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.AspNetCore.Mvc;
    using RESTCommon;

    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly List<WeatherForecast> Data = new List<WeatherForecast>
        {
            new WeatherForecast { Summary = "Cold" }
        };

        [HttpGet]
        public WeatherForecast Get() => Data.OrderBy(x => Guid.NewGuid()).FirstOrDefault();

        [HttpPost]
        public IActionResult Post(WeatherForecast weather)
        {
            if (string.IsNullOrEmpty(weather.Summary))
            {
                return this.BadRequest();
            }

            Data.Add(weather);

            return this.Ok();
        }
    }
}

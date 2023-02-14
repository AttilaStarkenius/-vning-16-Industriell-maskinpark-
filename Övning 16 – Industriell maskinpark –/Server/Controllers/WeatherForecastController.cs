using Microsoft.AspNetCore.Mvc;
using Övning_16___Industriell_maskinpark__.Shared;

namespace Övning_16___Industriell_maskinpark__.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        //public /*IEnumerable<*/WeatherForecast/*>*/ Get()
        public IEnumerable<WeatherForecast> Get()
        {
            //WeatherForecast weatherForecast = new WeatherForecast();
            //weatherForecast.Name = "Industrial machine";
            //return weatherForecast;
            return Enumerable.Range(1, /*2*/5).Select(index => new WeatherForecast
            {
                Name = "Industrial machine",
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

        }
    }
}
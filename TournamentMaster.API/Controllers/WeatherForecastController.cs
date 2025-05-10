using Microsoft.AspNetCore.Mvc;

namespace TournamentMaster.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }


        [HttpGet()]
        public IActionResult Get()
        {
            _logger.LogError("Testing AWS cloudwath configuration");
            return Ok();
        }
    }
}

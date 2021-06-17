using Microsoft.AspNetCore.Mvc;

namespace ReadingIsGood.Gateway.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        [HttpGet]
        public string Get() => "Sunny";
    }
}

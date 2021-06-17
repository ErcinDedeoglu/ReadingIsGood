using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReadingIsGood.Authorization.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class HealthCheckController : ControllerBase
    {
        [HttpGet("isalive")]
        public bool IsAlive()
        {
            return true;
        }

        [HttpGet("name")]
        public string Name()
        {
            return Assembly.GetExecutingAssembly().GetName().Name; ;
        }
    }
}
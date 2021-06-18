using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReadingIsGood.Business.Attribute;
using ReadingIsGood.Business.DTO.Response;

namespace ReadingIsGood.Customer.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public CustomerController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Authorize]
        public NewCustomerResponse Post(NewCustomerResponse model)
        {
            //TODO: insert customer
            //TODO: error response
            return new NewCustomerResponse();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReadingIsGood.Business.Attribute;
using ReadingIsGood.Business.DTO.Request;
using ReadingIsGood.Business.DTO.Response;

namespace ReadingIsGood.Order.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public OrderController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        public NewOrderResponse Post(NewOrderRequest newOrderRequest)
        {
            //TODO: insert customer
            //TODO: error response
            return new NewOrderResponse();
        }
    }
}
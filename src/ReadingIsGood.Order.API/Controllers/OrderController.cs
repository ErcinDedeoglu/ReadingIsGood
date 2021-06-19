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
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
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
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.Business.Attribute;
using ReadingIsGood.Business.DTO.Common;
using ReadingIsGood.Business.DTO.Request;
using ReadingIsGood.Business.DTO.Response;
using ReadingIsGood.Data.Interface.UOW;

namespace ReadingIsGood.Order.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewOrderRequest dto, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderService.AddOrder(dto, cancellationToken);

            return Created(string.Empty, new HttpServiceResponse<Data.Entity.Order> {Data = order, HttpStatusCode = HttpStatusCode.Created});
        }

        [HttpPost("customer/{customerId:int}")]
        public async Task<IActionResult> CustomerOrders(int customerId, PagingRequest paging, CancellationToken cancellationToken)
        {
            var customerOrdersResponse = await _unitOfWork.OrderService.CustomerOrders(customerId, paging, cancellationToken);

            if (customerOrdersResponse == null) throw new ApiException("Orders not found.", HttpStatusCode.NotFound);

            return Created(string.Empty, new HttpServiceResponse<CustomerOrdersResponse> {Data = customerOrdersResponse, HttpStatusCode = HttpStatusCode.Found});
        }

        [HttpPost("{orderId:int}")]
        public async Task<IActionResult> Get(int orderId, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.OrderService.Get(orderId, cancellationToken);

            if (order == null) throw new ApiException("Order not found.", HttpStatusCode.NotFound);

            return Created(string.Empty, new HttpServiceResponse<Data.Entity.Order> { Data = order, HttpStatusCode = HttpStatusCode.Found });
        }
    }
}
using System;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReadingIsGood.Business.Attribute;
using ReadingIsGood.Business.DTO.Common;
using ReadingIsGood.Business.DTO.Request;
using ReadingIsGood.Data.Entity;
using ReadingIsGood.Data.Enum;
using ReadingIsGood.Data.Interface;
using ReadingIsGood.Data.Interface.UOW;

namespace ReadingIsGood.Order.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(ILogger<OrderController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] NewOrderRequest dto, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerService.GetAsync(dto.CustomerId, cancellationToken);

            if (customer == null) throw new ApiException("Customer is not exists.", HttpStatusCode.BadRequest);
            if (customer.Deleted) throw new ApiException("Customer is deleted.", HttpStatusCode.BadRequest);
            if (dto.Products.Count == 0) throw new ApiException("No products have been added to the order content.", HttpStatusCode.BadRequest);

            var order = new Data.Entity.Order()
            {
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                OrderStatus = OrderStatus.New,
                Customer = customer,
                OrderDetails = dto.Products.Select(a =>
                {
                    var product = _unitOfWork.ProductService.GetAsync(a.ProductId, cancellationToken).Result;
                    if (product == null) throw new ApiException("The product with id number " + a.ProductId + " is not exists.", HttpStatusCode.BadRequest);

                    product.AmountOfStock = -a.Amount; //TODO: Check

                    return new OrderDetail()
                    {
                        Product = product,
                        Amount = a.Amount,
                        CreateDate = DateTime.UtcNow,
                        UpdateDate = DateTime.UtcNow,
                        OrderDetailStatus = OrderDetailStatus.New
                    };
                }).ToList()
            };
            await _unitOfWork.OrderService.InsertAsync(order, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Created(string.Empty, new HttpServiceResponse<Data.Entity.Order> { Data = order, HttpStatusCode = HttpStatusCode.Created });
        }
        
        //[HttpGet("customer/{customerId:int}")]
        //public async Task<IActionResult> CustomerOrders(int customerId, CancellationToken cancellationToken)
        //{
        //    var order = await _orderService.GetAsync(customerId, cancellationToken);

        //    if (order == null) throw new ApiException("Customer not found.", HttpStatusCode.NotFound);

        //    return Created(string.Empty, new HttpServiceResponse<Data.Entity.Customer> { Data = order, HttpStatusCode = HttpStatusCode.Found });
        //}
    }
}
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ReadingIsGood.Business.DTO.Common;
using ReadingIsGood.Business.DTO.Request;
using ReadingIsGood.Data.Interface;

namespace ReadingIsGood.Customer.API.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NewCustomerRequest dto, CancellationToken cancellationToken)
        {
            var customer = new Data.Entity.Customer()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
            await _customerService.InsertAsync(customer, cancellationToken);
            await _customerService.CommitAsync(cancellationToken);

            return Created(string.Empty, new HttpServiceResponse<Data.Entity.Customer> { Data = customer, HttpStatusCode = HttpStatusCode.Created });
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var customers = _customerService.All();

            if (customers == null) throw new ApiException("An error occurred while fetching customers.", HttpStatusCode.NotFound);

            return Created(string.Empty, new HttpServiceResponse<IEnumerable<Data.Entity.Customer>> { Data = customers, HttpStatusCode = HttpStatusCode.Found });
        }
        
        [HttpGet("{customerId:int}")]
        public async Task<IActionResult> Get(int customerId, CancellationToken cancellationToken)
        {
            var customer = await _customerService.GetAsync(customerId, cancellationToken);

            if (customer == null) throw new ApiException("Customer not found.", HttpStatusCode.NotFound);

            return Created(string.Empty, new HttpServiceResponse<Data.Entity.Customer> { Data = customer, HttpStatusCode = HttpStatusCode.Found });
        }
    }
}
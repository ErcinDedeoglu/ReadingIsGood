using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.Business.Attribute;
using ReadingIsGood.Business.DTO.Common;
using ReadingIsGood.Business.DTO.Request;
using ReadingIsGood.Data.Interface.UOW;

namespace ReadingIsGood.Customer.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NewCustomerRequest dto, CancellationToken cancellationToken)
        {
            var customer = new Data.Entity.Customer()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
            await _unitOfWork.CustomerService.InsertAsync(customer, cancellationToken);
            await _unitOfWork.CommitAsync(cancellationToken);

            return Created(string.Empty, new HttpServiceResponse<Data.Entity.Customer> { Data = customer, HttpStatusCode = HttpStatusCode.Created });
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var customers = _unitOfWork.CustomerService.All();

            if (customers == null) throw new ApiException("An error occurred while fetching customers.", HttpStatusCode.NotFound);

            return Created(string.Empty, new HttpServiceResponse<IEnumerable<Data.Entity.Customer>> { Data = customers, HttpStatusCode = HttpStatusCode.Found });
        }
        
        [HttpGet("{customerId:int}")]
        public async Task<IActionResult> Get(int customerId, CancellationToken cancellationToken)
        {
            var customer = await _unitOfWork.CustomerService.GetAsync(customerId, cancellationToken);

            if (customer == null) throw new ApiException("Customer not found.", HttpStatusCode.NotFound);

            return Created(string.Empty, new HttpServiceResponse<Data.Entity.Customer> { Data = customer, HttpStatusCode = HttpStatusCode.Found });
        }
    }
}
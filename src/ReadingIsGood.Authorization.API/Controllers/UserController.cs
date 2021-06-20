using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.Business.DTO.Common;
using ReadingIsGood.Business.DTO.Request;
using ReadingIsGood.Business.DTO.Response;
using ReadingIsGood.Data.Interface.UOW;

namespace ReadingIsGood.Authorization.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public UsersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var authenticateResponse = _unitOfWork.UserService.Authenticate(model);

            if (authenticateResponse == null) throw new ApiException("Username or password is incorrect", HttpStatusCode.Unauthorized);

            return Created(string.Empty, new HttpServiceResponse<AuthenticateResponse> { Data = authenticateResponse, HttpStatusCode = HttpStatusCode.Created });
        }
    }
}

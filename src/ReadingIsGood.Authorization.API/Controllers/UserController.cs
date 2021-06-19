using System.Net;
using Microsoft.AspNetCore.Mvc;
using ReadingIsGood.Business.DTO.Common;
using ReadingIsGood.Business.DTO.Request;
using ReadingIsGood.Business.DTO.Response;
using ReadingIsGood.Data.Interface;

namespace ReadingIsGood.Authorization.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var authenticateResponse = _userService.Authenticate(model);

            if (authenticateResponse == null) throw new ApiException("Username or password is incorrect", HttpStatusCode.Unauthorized);

            return Created(string.Empty, new HttpServiceResponse<AuthenticateResponse> { Data = authenticateResponse, HttpStatusCode = HttpStatusCode.Created });
        }
    }
}

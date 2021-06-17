using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ReadingIsGood.Data.Interface;

namespace ReadingIsGood.Business.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IJwtService jwtService, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null) jwtService.AttachUserToContext(context, userService, token);

            await _next(context);
        }
    }
}
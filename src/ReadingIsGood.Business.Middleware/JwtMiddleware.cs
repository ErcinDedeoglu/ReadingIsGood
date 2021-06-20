using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ReadingIsGood.Data.Interface.UOW;

namespace ReadingIsGood.Business.Middleware
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUnitOfWork unitOfWork)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null) unitOfWork.JwtService.AttachUserToContext(context, unitOfWork.UserService, token);

            await _next(context);
        }
    }
}
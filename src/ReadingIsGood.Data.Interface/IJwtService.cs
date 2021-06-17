using Microsoft.AspNetCore.Http;
using ReadingIsGood.Data.Entity;

namespace ReadingIsGood.Data.Interface
{
    public interface IJwtService
    {
        public string GenerateJwtToken(User user);
        void AttachUserToContext(HttpContext context, IUserService userService, string token);
    }
}
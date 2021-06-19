using System;
using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using ReadingIsGood.Business.DTO.Common;
using ReadingIsGood.Data.Entity;

namespace ReadingIsGood.Business.Attribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : System.Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (User) context.HttpContext.Items["User"];
            if (user == null) throw new ApiException("Token is not found. Try again with token.", HttpStatusCode.Unauthorized);
        }
    }
}
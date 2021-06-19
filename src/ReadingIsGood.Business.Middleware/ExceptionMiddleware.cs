using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ReadingIsGood.Business.DTO.Common;

namespace ReadingIsGood.Business.Middleware
{
    public class ExceptionMiddleware
    {
        public static void Init(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.Run(async httpContext =>
            {
                var exceptionHandlerFeature = httpContext.Features.Get<IExceptionHandlerFeature>();

                httpContext.Response.ContentType = "application/json";

                var response = new HttpServiceResponse();

                if (exceptionHandlerFeature.Error is ApiException apiException)
                {
                    httpContext.Response.StatusCode = (int) apiException.HttpStatusCode;
                    response.Exception = new ExceptionModel
                    {
                        HttpStatusCode = apiException.HttpStatusCode,
                        Message = apiException.ExceptionMessage,
                        Exception = "Handled Exception"
                    };
                }
                else
                {
                    httpContext.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    response.Exception = new ExceptionModel
                    {
                        HttpStatusCode = HttpStatusCode.InternalServerError,
                        Message = "Unhandled error",
                        Exception = exceptionHandlerFeature.Error.Message
                    };
                }

                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
            });
        }
    }
}
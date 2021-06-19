using System;
using System.Net;

namespace ReadingIsGood.Business.DTO.Common
{
    public class ApiException : Exception
    {
        public string ExceptionMessage { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }

        public ApiException(string exceptionMessage, HttpStatusCode httpStatusCode)
        {
            ExceptionMessage = exceptionMessage;
            HttpStatusCode = httpStatusCode;
        }
    }
}
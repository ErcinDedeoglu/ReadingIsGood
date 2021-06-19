using System.Net;

namespace ReadingIsGood.Business.DTO.Common
{
    public class HttpServiceResponse
    {
        public ExceptionModel Exception { get; set; }
    }

    public class HttpServiceResponse<T>
    {
        public T Data { get; set; }

        public HttpStatusCode HttpStatusCode { get; set; }
    }

    public class ExceptionModel
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public string Message { get; set; }

        public string Exception { get; set; }
    }
}

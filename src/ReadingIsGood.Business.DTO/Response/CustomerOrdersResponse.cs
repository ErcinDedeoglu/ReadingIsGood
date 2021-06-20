using System.ComponentModel.DataAnnotations;

namespace ReadingIsGood.Business.DTO.Response
{
    public class CustomerOrdersResponse : PagingResponse
    {
        public dynamic Items { get; set; }
    }
}
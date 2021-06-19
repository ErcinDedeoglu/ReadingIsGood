using System.Collections.Generic;

namespace ReadingIsGood.Business.DTO.Request
{
    public class NewOrderRequest
    {
        public int CustomerId { get; set; }
        public List<NewOrderProductRequest> Products { get; set; }
    }

    public class NewOrderProductRequest
    {
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
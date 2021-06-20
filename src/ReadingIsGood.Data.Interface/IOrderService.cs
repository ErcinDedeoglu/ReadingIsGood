using System.Threading;
using System.Threading.Tasks;
using ReadingIsGood.Business.DTO.Request;
using ReadingIsGood.Business.DTO.Response;
using ReadingIsGood.Data.Entity;
using ReadingIsGood.Data.Interface.UOW;

namespace ReadingIsGood.Data.Interface
{
    public interface IOrderService : IRepository<Entity.Order>
    {
        Task<CustomerOrdersResponse> CustomerOrders(int customerId, PagingRequest paging, CancellationToken cancellationToken);

        Task<Order> AddOrder(NewOrderRequest newOrderRequest, CancellationToken cancellationToken);

        Task<Order> Get(int orderId, CancellationToken cancellationToken);
    }
}
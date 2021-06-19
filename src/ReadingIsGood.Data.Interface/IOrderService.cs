using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ReadingIsGood.Data.Entity;
using ReadingIsGood.Data.Interface.UOW;

namespace ReadingIsGood.Data.Interface
{
    public interface IOrderService : IRepository<Entity.Order>
    {
        IEnumerable<Order> All();

        Task<Order> GetAsync(int orderId, CancellationToken cancellationToken);

        Task InsertAsync(Order order, CancellationToken cancellationToken);
    }
}
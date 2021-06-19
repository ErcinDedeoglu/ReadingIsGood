using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ReadingIsGood.Context;
using ReadingIsGood.Data.Entity;
using ReadingIsGood.Data.Interface;
using ReadingIsGood.Data.Service.UOW;

namespace ReadingIsGood.Data.Service
{
    public class OrderService : Repository<Order>, IOrderService
    {
        private readonly DataContext _dataContext;

        public OrderService(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Order> All()
        {
            return _dataContext.Orders.Where(a => !a.Deleted);
        }

        public async Task<Order> GetAsync(int orderId, CancellationToken cancellationToken)
        {
            return await _dataContext.Orders.FindAsync(orderId, cancellationToken);
        }

        public async Task InsertAsync(Order order, CancellationToken cancellationToken)
        {
            await _dataContext.Orders.AddAsync(order, cancellationToken);
        }
    }
}
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ReadingIsGood.Data.Entity;
using ReadingIsGood.Data.Interface.UOW;

namespace ReadingIsGood.Data.Interface
{
    public interface ICustomerService : IRepository<Entity.Customer>
    {
        IEnumerable<Customer> All();

        Task<Customer> GetAsync(int customerId, CancellationToken cancellationToken);

        Task InsertAsync(Customer customer, CancellationToken cancellationToken);
    }
}
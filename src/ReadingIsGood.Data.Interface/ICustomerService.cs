using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ReadingIsGood.Data.Entity;

namespace ReadingIsGood.Data.Interface
{
    public interface ICustomerService
    {
        IEnumerable<Customer> All();

        Task<Customer> GetAsync(int customerId, CancellationToken cancellationToken);

        Task InsertAsync(Customer customer, CancellationToken cancellationToken);

        Task CommitAsync(CancellationToken cancellationToken);
    }
}
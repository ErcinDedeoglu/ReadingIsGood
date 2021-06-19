using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ReadingIsGood.Context;
using ReadingIsGood.Data.Entity;
using ReadingIsGood.Data.Interface;

namespace ReadingIsGood.Data.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _dataContext;

        public CustomerService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Customer> All()
        {
            return _dataContext.Customers.Where(a => !a.Deleted);
        }

        public async Task<Customer> GetAsync(int customerId, CancellationToken cancellationToken)
        {
            return await _dataContext.Customers.FindAsync(customerId, cancellationToken);
        }

        public async Task InsertAsync(Customer customer, CancellationToken cancellationToken)
        {
            await _dataContext.Customers.AddAsync(customer, cancellationToken);
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _dataContext.SaveChangesAsync(null, cancellationToken);
        }
    }
}
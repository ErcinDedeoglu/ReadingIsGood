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
    public class CustomerService : Repository<Customer>, ICustomerService
    {
        private readonly DataContext _dataContext;

        public CustomerService(DataContext dataContext) : base(dataContext)
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
    }
}
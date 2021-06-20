using System.Collections.Generic;
using System.Linq;
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
    }
}
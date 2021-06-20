using System.Collections.Generic;
using ReadingIsGood.Data.Entity;
using ReadingIsGood.Data.Interface.UOW;

namespace ReadingIsGood.Data.Interface
{
    public interface ICustomerService : IRepository<Entity.Customer>
    {
        IEnumerable<Customer> All();
    }
}
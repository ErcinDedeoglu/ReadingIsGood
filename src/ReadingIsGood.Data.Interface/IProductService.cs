using System.Collections.Generic;
using ReadingIsGood.Data.Entity;
using ReadingIsGood.Data.Interface.UOW;

namespace ReadingIsGood.Data.Interface
{
    public interface IProductService : IRepository<Entity.Product>
    {
        IEnumerable<Product> ActiveRecords();
    }
}
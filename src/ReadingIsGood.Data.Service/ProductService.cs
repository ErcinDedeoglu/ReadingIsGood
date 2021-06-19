using System.Collections.Generic;
using System.Linq;
using ReadingIsGood.Context;
using ReadingIsGood.Data.Entity;
using ReadingIsGood.Data.Interface;
using ReadingIsGood.Data.Service.UOW;

namespace ReadingIsGood.Data.Service
{
    public class ProductService : Repository<Product>, IProductService
    {
        private readonly DataContext _dataContext;

        public ProductService(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<Product> ActiveRecords()
        {
            return _dataContext.Products.Where(a => !a.Deleted);
        }
    }
}
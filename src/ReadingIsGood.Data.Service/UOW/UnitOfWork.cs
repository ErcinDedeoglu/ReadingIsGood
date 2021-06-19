using System.Threading;
using System.Threading.Tasks;
using ReadingIsGood.Context;
using ReadingIsGood.Data.Interface;
using ReadingIsGood.Data.Interface.UOW;

namespace ReadingIsGood.Data.Service.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dbContext)
        {
            _dataContext = dbContext;
        }

        private IAuditLogService _auditLogService;

        public IAuditLogService AuditLogService
        {
            get { return _auditLogService ??= new AuditLogService(_dataContext); }
        }

        private ICustomerService _customerService;

        public ICustomerService CustomerService
        {
            get { return _customerService ??= new CustomerService(_dataContext); }
        }

        private IOrderService _orderService;

        public IOrderService OrderService
        {
            get { return _orderService ??= new OrderService(_dataContext); }
        }

        private IProductService _productService;

        public IProductService ProductService
        {
            get { return _productService ??= new ProductService(_dataContext); }
        }

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _dataContext.SaveChangesAsync(null, cancellationToken);
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
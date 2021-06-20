using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using ReadingIsGood.Business.DTO.Internal;
using ReadingIsGood.Context;
using ReadingIsGood.Data.Interface;
using ReadingIsGood.Data.Interface.UOW;

namespace ReadingIsGood.Data.Service.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private readonly IOptions<AppSettings> _appSettings;

        public UnitOfWork(DataContext dbContext, IOptions<AppSettings> appSettings)
        {
            _dataContext = dbContext;
            _appSettings = appSettings;
        }

        private IUserService _userService;

        public IUserService UserService
        {
            get { return _userService ??= new UserService(this); }
        }

        private IJwtService _jwtService;

        public IJwtService JwtService
        {
            get { return _jwtService ??= new JwtService(_appSettings); }
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
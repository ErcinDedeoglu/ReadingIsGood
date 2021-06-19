using ReadingIsGood.Context;
using ReadingIsGood.Data.Entity;
using ReadingIsGood.Data.Interface;
using ReadingIsGood.Data.Service.UOW;

namespace ReadingIsGood.Data.Service
{
    public class AuditLogService : Repository<AuditLog>, IAuditLogService
    {
        public AuditLogService(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
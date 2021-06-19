using ReadingIsGood.Data.Interface.UOW;

namespace ReadingIsGood.Data.Interface
{
    public interface IAuditLogService : IRepository<Entity.AuditLog>
    {
    }
}
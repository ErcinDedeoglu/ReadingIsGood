using System.Collections.Generic;
using ReadingIsGood.Data.Entity;

namespace ReadingIsGood.Data.Interface
{
    public interface IAuditLogService
    {
        IEnumerable<AuditLog> All();
    }
}
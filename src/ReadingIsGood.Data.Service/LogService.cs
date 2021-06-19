using System.Collections.Generic;
using ReadingIsGood.Context;
using ReadingIsGood.Data.Entity;
using ReadingIsGood.Data.Interface;

namespace ReadingIsGood.Data.Service
{
    public class AuditLogService : IAuditLogService
    {
        private readonly DataContext _dataContext;

        public AuditLogService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IEnumerable<AuditLog> All()
        {
            return _dataContext.AuditLogs;
        }
    }
}
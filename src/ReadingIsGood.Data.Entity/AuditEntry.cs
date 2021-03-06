using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using ReadingIsGood.Data.Enum;

namespace ReadingIsGood.Data.Entity
{
    public class AuditEntry
    {
        public AuditEntry(EntityEntry entry)
        {
            Entry = entry;
        }
        public EntityEntry Entry { get; }

        public int? UserId { get; set; }

        public string TableName { get; set; }

        public Dictionary<string, object> KeyValues { get; } = new Dictionary<string, object>();

        public Dictionary<string, object> OldValues { get; } = new Dictionary<string, object>();

        public Dictionary<string, object> NewValues { get; } = new Dictionary<string, object>();

        public AuditType AuditType { get; set; }

        public List<string> ChangedColumns { get; } = new List<string>();

        public AuditLog ToAudit()
        {
            return new AuditLog
            {
                UserId = UserId,
                Type = AuditType.ToString(),
                TableName = TableName,
                DateTime = DateTime.Now,
                PrimaryKey = JsonConvert.SerializeObject(KeyValues),
                OldValues = OldValues.Count == 0 ? null : JsonConvert.SerializeObject(OldValues),
                NewValues = NewValues.Count == 0 ? null : JsonConvert.SerializeObject(NewValues),
                AffectedColumns = ChangedColumns.Count == 0 ? null : JsonConvert.SerializeObject(ChangedColumns)
            };
        }
    }
}
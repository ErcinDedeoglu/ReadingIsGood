﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReadingIsGood.Data.Entity;
using ReadingIsGood.Data.Enum;

namespace ReadingIsGood.Context
{
    public abstract class AuditableDataContext : DbContext
    {
        protected AuditableDataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<AuditLog> AuditLogs { get; set; }

        public virtual async Task<int> SaveChangesAsync(int? userId = null, CancellationToken cancellationToken = default)
        {
            OnBeforeSaveChanges(userId);
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        private void OnBeforeSaveChanges(int? userId)
        {
            ChangeTracker.DetectChanges();
            var auditEntries = new List<AuditEntry>();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is AuditLog || entry.State == EntityState.Detached ||
                    entry.State == EntityState.Unchanged)
                    continue;
                var auditEntry = new AuditEntry(entry) {TableName = entry.Entity.GetType().Name, UserId = userId};
                auditEntries.Add(auditEntry);
                foreach (var property in entry.Properties)
                {
                    var propertyName = property.Metadata.Name;
                    if (property.Metadata.IsPrimaryKey())
                    {
                        auditEntry.KeyValues[propertyName] = property.CurrentValue;
                        continue;
                    }

                    switch (entry.State)
                    {
                        case EntityState.Added:
                            auditEntry.AuditType = AuditType.Create;
                            auditEntry.NewValues[propertyName] = property.CurrentValue;
                            break;
                        case EntityState.Deleted:
                            auditEntry.AuditType = AuditType.Delete;
                            auditEntry.OldValues[propertyName] = property.OriginalValue;
                            break;
                        case EntityState.Modified:
                            if (property.IsModified)
                            {
                                auditEntry.ChangedColumns.Add(propertyName);
                                auditEntry.AuditType = AuditType.Update;
                                auditEntry.OldValues[propertyName] = property.OriginalValue;
                                auditEntry.NewValues[propertyName] = property.CurrentValue;
                            }
                            break;
                    }
                }
            }

            foreach (var auditEntry in auditEntries) AuditLogs.Add(auditEntry.ToAudit());
        }
    }
}
﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace ReadingIsGood.Data.Interface.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IAuditLogService AuditLogService { get; }

        ICustomerService CustomerService { get; }

        IOrderService OrderService { get; }

        IProductService ProductService { get; }
        
        Task CommitAsync(CancellationToken cancellationToken);
    }
}
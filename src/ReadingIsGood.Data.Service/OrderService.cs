using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReadingIsGood.Business.DTO.Common;
using ReadingIsGood.Business.DTO.Request;
using ReadingIsGood.Business.DTO.Response;
using ReadingIsGood.Context;
using ReadingIsGood.Data.Entity;
using ReadingIsGood.Data.Enum;
using ReadingIsGood.Data.Interface;
using ReadingIsGood.Data.Service.UOW;

namespace ReadingIsGood.Data.Service
{
    public class OrderService : Repository<Order>, IOrderService
    {
        private readonly DataContext _dataContext;

        public OrderService(DataContext dataContext) : base(dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<CustomerOrdersResponse> CustomerOrders(int customerId, PagingRequest paging, CancellationToken cancellationToken)
        {
            var orders = _dataContext.Orders
                .Include(a => a.OrderDetails)
                .ThenInclude(a => a.Product)
                .ThenInclude(a => a.Category)
                .Where(a => a.CustomerId == customerId);

            var recordCount = await orders.CountAsync(cancellationToken: cancellationToken);
            return new CustomerOrdersResponse()
            {
                Page = paging.Page,
                PageCount = (int) Math.Ceiling(decimal.Divide(recordCount, paging.Quantity)),
                RecordCount = recordCount,
                Items = await orders.Skip(paging.Skip).Take(paging.Quantity).ToListAsync(cancellationToken: cancellationToken),
            };
        }

        public async Task<int> AddOrder(NewOrderRequest newOrderRequest, CancellationToken cancellationToken)
        {
            var customer = await _dataContext.Customers.FindAsync(new object[] {newOrderRequest.CustomerId}, cancellationToken);

            if (customer == null) throw new ApiException("Customer is not exists.", HttpStatusCode.BadRequest);
            if (customer.Deleted) throw new ApiException("Customer is deleted.", HttpStatusCode.BadRequest);
            if (newOrderRequest.Products.Count == 0) throw new ApiException("No products have been added to the order content.", HttpStatusCode.BadRequest);

            var order = new Order()
            {
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow,
                OrderStatus = OrderStatus.New,
                Customer = customer,
                OrderDetails = newOrderRequest.Products.Select(a =>
                {
                    var product = _dataContext.Products.FindAsync(new object[] {a.ProductId}, cancellationToken).Result;
                    if (product == null) throw new ApiException("The product with id number " + a.ProductId + " is not exists.", HttpStatusCode.BadRequest);

                    product.AmountOfStock = -a.Amount; //TODO: Check

                    return new OrderDetail()
                    {
                        Product = product,
                        Amount = a.Amount,
                        CreateDate = DateTime.UtcNow,
                        UpdateDate = DateTime.UtcNow,
                        OrderDetailStatus = OrderDetailStatus.New
                    };
                }).ToList()
            };
            await _dataContext.Orders.AddAsync(order, cancellationToken);
            await _dataContext.SaveChangesAsync(null, cancellationToken);

            return order.Id;
        }


        public async Task<Order> Get(int orderId, CancellationToken cancellationToken)
        {
            var order = await _dataContext.Orders
                .Include(a => a.OrderDetails)
                .ThenInclude(a => a.Product)
                .ThenInclude(a => a.Category)
                .SingleOrDefaultAsync(a => a.Id == orderId, cancellationToken: cancellationToken);
            
            return order;
        }
    }
}
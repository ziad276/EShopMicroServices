
namespace Ordering.Application.Orders.Queries.GetOrderByCustomer
{
    public class GetOrdersByCustomerHandler(IApplicationDbContext dbContext) :
        IQueryHandler<GetOrdersByCustomerQuery, GetOrdersByCustomerResult>
    {
        public async Task<GetOrdersByCustomerResult> Handle(GetOrdersByCustomerQuery query, CancellationToken cancellationToken)
        {
            var orders = await dbContext.Orders
                .Include(o => o.OrderItems)
                .AsNoTracking() // Use AsNoTracking() when this query is only for **read-only purposes**
                .Where(o => o.CustomerId == CustomerId.Of(query.CustomerId))
                .OrderBy(o => o.OrderName.Value)
                .ToListAsync(cancellationToken);
                

            return new GetOrdersByCustomerResult(orders.ToOrderDtoList());
        }
    }

}

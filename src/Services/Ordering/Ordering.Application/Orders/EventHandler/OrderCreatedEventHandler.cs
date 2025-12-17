using MediatR;
using Microsoft.Extensions.Logging;
using Ordering.Domain.Events;

namespace Ordering.Application.Orders.EventHandler
{
    public class OrderCreatedEventHandler(ILogger<OrderCreatedEventHandler> logger) : 
        INotificationHandler<OrderCreatedEvent>
    {
        public Task Handle(OrderCreatedEvent notification, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            logger.LogInformation("Domain Event handled:{DomainEvent}",
                notification.GetType());
            return Task.CompletedTask;
        }
    }
}

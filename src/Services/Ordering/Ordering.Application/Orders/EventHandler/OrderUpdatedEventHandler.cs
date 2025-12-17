namespace Ordering.Application.Orders.EventHandler
{
    public class OrderUpdatedEventHandler(ILogger<OrderUpdatedEventHandler> logger) :
        INotificationHandler<OrderUpdatedEvent>
    {
        public Task Handle(OrderUpdatedEvent notification, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled:{DomainEvent}",
                notification.GetType());
            return Task.CompletedTask;
        }
    }
}

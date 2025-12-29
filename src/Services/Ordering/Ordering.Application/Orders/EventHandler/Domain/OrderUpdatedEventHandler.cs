namespace Ordering.Application.Orders.EventHandler.Domain
{
    public class OrderUpdatedEventHandler(ILogger<OrderUpdatedEventHandler> logger) :
        INotificationHandler<OrderUpdatedEvent>
    {
        public Task Handle(OrderUpdatedEvent domainEvent, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled:{DomainEvent}",
                domainEvent.GetType());
            return Task.CompletedTask;
        }
    }
}

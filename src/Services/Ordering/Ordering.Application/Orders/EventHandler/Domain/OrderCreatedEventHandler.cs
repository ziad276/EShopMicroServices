using MassTransit;
using MassTransit.RabbitMqTransport;

namespace Ordering.Application.Orders.EventHandler.Domain
{
    public class OrderCreatedEventHandler(IPublishEndpoint publishEndpoint ,ILogger<OrderCreatedEventHandler> logger) : 
        INotificationHandler<OrderCreatedEvent>
    {
        public async Task Handle(OrderCreatedEvent domainEvent, CancellationToken cancellationToken)
        {
            logger.LogInformation("Domain Event handled:{DomainEvent}",domainEvent.GetType());
            var orderCreatedEvent = domainEvent.ToOrderDto();
            await publishEndpoint.Publish(orderCreatedEvent, cancellationToken);

            
        }
    }
}

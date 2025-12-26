namespace BuildingBlocks.Messaging.Events
{
    public record IntegrationEvent
    {
        public Guid id => Guid.NewGuid();
        public DateTime occurredOn => DateTime.Now;
        public string EventType => GetType().AssemblyQualifiedName;
    }
}

using BuildingBlocks.CQRS;

namespace Ordering.Application.Orders.Commands.CreateOrder
{
    public record CreateOrderHandler : ICommandHandler<CreateOrderCommand, CreateOrderResult>
    {
        public Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            

            throw new NotImplementedException();
        }
    }
}

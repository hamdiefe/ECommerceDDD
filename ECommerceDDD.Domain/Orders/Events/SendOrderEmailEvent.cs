using MediatR;

namespace ECommerceDDD.Domain.Orders.Events
{
	public sealed class SendOrderEmailEvent : INotificationHandler<OrderDomainEvent>
	{
		public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
		{
			//mail gönderme işlemi
			return Task.CompletedTask;
		}
	}
}

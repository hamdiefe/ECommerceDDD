using MediatR;

namespace ECommerceDDD.Domain.Orders.Events
{
	public sealed class SendOrderSmsEvent : INotificationHandler<OrderDomainEvent>
	{
		public Task Handle(OrderDomainEvent notification, CancellationToken cancellationToken)
		{
			//sms gönderme işlemi
			return Task.CompletedTask;
		}
	}
}

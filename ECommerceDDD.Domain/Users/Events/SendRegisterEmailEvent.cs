using MediatR;

namespace ECommerceDDD.Domain.Users.Events
{
	public sealed class SendRegisterEmailEvent : INotificationHandler<UserDomainEvent>
	{
		public Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
		{
            //Email gönderme işlemleri
            return Task.CompletedTask;
        }
	}
}

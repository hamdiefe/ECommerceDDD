using ECommerceDDD.Domain.Abstractions;
using ECommerceDDD.Domain.Categories;
using ECommerceDDD.Domain.Orders.Events;
using MediatR;

namespace ECommerceDDD.Application.Features.Orders.CreateOrder
{
	internal sealed class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMediator _mediator;
		public CreateOrderCommandHandler(IOrderRepository orderRepository,
										 IUnitOfWork unitOfWork,
										 IMediator mediator)
		{
			_orderRepository = orderRepository;
			_unitOfWork = unitOfWork;
			_mediator = mediator;
		}

		public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
		{
			var order = await _orderRepository.CreateAsync(request.CreateOrderDtos, cancellationToken);
			await _unitOfWork.SaveChangesAsync(cancellationToken);
			await _mediator.Publish(new OrderDomainEvent(order));
		}
	}
}

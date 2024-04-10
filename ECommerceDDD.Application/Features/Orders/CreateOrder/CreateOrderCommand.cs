using ECommerceDDD.Domain.Orders;
using MediatR;

namespace ECommerceDDD.Application.Features.Orders.CreateOrder
{
	public sealed record CreateOrderCommand(List<CreateOrderDto> CreateOrderDtos) : IRequest;
}

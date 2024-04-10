using ECommerceDDD.Domain.Orders;
using MediatR;

namespace ECommerceDDD.Application.Features.Categories.GetAllOrder
{
	public sealed record class GetAllOrderQuery() : IRequest<List<Order>>;
}

using ECommerceDDD.Domain.Orders;

namespace ECommerceDDD.Domain.Categories
{
	public interface IOrderRepository
	{
		Task<Order> CreateAsync(List<CreateOrderDto> createOrderDtos, CancellationToken cancellationToken = default);

		Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default);
	}
}

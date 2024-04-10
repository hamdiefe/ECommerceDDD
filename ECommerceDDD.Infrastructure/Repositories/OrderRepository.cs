﻿using ECommerceDDD.Domain.Categories;
using ECommerceDDD.Domain.Orders;
using ECommerceDDD.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDDD.Infrastructure.Repositories
{
	internal sealed class OrderRepository : IOrderRepository
	{
		private readonly ApplicationDbContext _context;

		public OrderRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<Order> CreateAsync(List<CreateOrderDto> createOrderDtos, CancellationToken cancellationToken = default)
		{
			var order = new Order(
				Guid.NewGuid(),
				"1",
				DateTime.Now,
				OrderStatusEnum.AwaitingApproval);

			order.CreateOrder(createOrderDtos);

			await _context.Orders.AddAsync(order, cancellationToken);
			return order;
		}

		public async Task<List<Order>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			return
				await _context.Orders
				.Include(p => p.OrderLines)
				.ThenInclude(p => p.Product)
				.ToListAsync(cancellationToken);
		}
	}
}

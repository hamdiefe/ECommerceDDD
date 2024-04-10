using ECommerceDDD.Domain.Products;
using ECommerceDDD.Domain.Shared;
using ECommerceDDD.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDDD.Infrastructure.Repositories
{
	internal sealed class ProductRepository : IProductRepository
	{
		private readonly ApplicationDbContext _context;

		public ProductRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task CreateAsync(string name, int quantity, decimal amount, string currency, Guid categoryId, CancellationToken cancellationToken = default)
		{
			var product = new Product(
				Guid.NewGuid(),
				new Name(name),
				quantity,
				new Money(amount, Currency.FromCode(currency)),
				categoryId);

			await _context.Products.AddAsync(product, cancellationToken);
		}

		public async Task<List<Product>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			return await _context.Products.ToListAsync(cancellationToken);
		}
	}
}

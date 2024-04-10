using ECommerceDDD.Domain.Categories;
using ECommerceDDD.Domain.Shared;
using ECommerceDDD.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDDD.Infrastructure.Repositories;
internal sealed class CategoryRepository : ICategoryRepository
{
	private readonly ApplicationDbContext _context;

	public CategoryRepository(ApplicationDbContext context)
	{
		_context = context;
	}

	public async Task CreateAsync(string name, CancellationToken cancellationToken = default)
	{
		Category category = new Category(Guid.NewGuid(), new Name(name));
		await _context.Categories.AddAsync(category, cancellationToken);
	}

	public async Task<List<Category>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		return await _context.Categories.ToListAsync(cancellationToken);
	}
}
using ECommerceDDD.Domain.Abstractions;
using ECommerceDDD.Domain.Categories;
using ECommerceDDD.Domain.Products;
using ECommerceDDD.Domain.Users;
using ECommerceDDD.Infrastructure.Context;
using ECommerceDDD.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerceDDD.Infrastructure
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddScoped<ApplicationDbContext>();
			services.AddScoped<IUnitOfWork>(opt => opt.GetRequiredService<ApplicationDbContext>());

			services.AddScoped<IProductRepository, ProductRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
			return services;
		}
	}
}

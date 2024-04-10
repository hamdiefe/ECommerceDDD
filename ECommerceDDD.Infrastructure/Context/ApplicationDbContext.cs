using ECommerceDDD.Domain.Abstractions;
using ECommerceDDD.Domain.Categories;
using ECommerceDDD.Domain.Orders;
using ECommerceDDD.Domain.Products;
using ECommerceDDD.Domain.Shared;
using ECommerceDDD.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace ECommerceDDD.Infrastructure.Context
{
	internal sealed class ApplicationDbContext : DbContext, IUnitOfWork
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ECommerceDDD;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
		   .Property(p => p.Name)
		   .HasConversion(name => name.Value, value => new(value));

			modelBuilder.Entity<User>()
			   .Property(p => p.Email)
			   .HasConversion(email => email.Value, value => new(value));

			modelBuilder.Entity<User>()
			   .Property(p => p.Password)
			   .HasConversion(password => password.Value, value => new(value));

			modelBuilder.Entity<User>()
				.OwnsOne(p => p.Address);

			modelBuilder.Entity<Category>()
				.Property(p => p.Name)
				.HasConversion(name => name.Value, value => new(value));

			modelBuilder.Entity<Product>()
				.Property(p => p.Name)
				.HasConversion(name => name.Value, value => new(value));

			modelBuilder.Entity<Product>()
				.OwnsOne(p => p.Price, priceBuilder =>
				{
					priceBuilder
					.Property(p => p.Currency)
					.HasConversion(currency => currency.Code, code => Currency.FromCode(code));

					priceBuilder
					.Property(p => p.Amount)
					.HasColumnType("money");
				});

			modelBuilder.Entity<OrderLine>()
				.OwnsOne(p => p.Price, priceBuilder =>
				{
					priceBuilder
					.Property(p => p.Currency)
					.HasConversion(currency => currency.Code, code => Currency.FromCode(code));

					priceBuilder
					.Property(p => p.Amount)
					.HasColumnType("money");
				});
		}
	}
}

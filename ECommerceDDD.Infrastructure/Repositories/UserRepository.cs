using ECommerceDDD.Domain.Users;
using ECommerceDDD.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDDD.Infrastructure.Repositories
{
	internal sealed class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _context;

		public UserRepository(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<User> CreateAsync(string name, string email, string password, string country, string city, string street, string fullAddress, string postalCode, CancellationToken cancellationToken = default)
		{
			var user = User.CreateUser(name, email, password, country, city, street, fullAddress, postalCode);
			await _context.Users.AddAsync(user, cancellationToken);
			return user;
		}

		public async Task<List<User>> GetAllAsync(CancellationToken cancellationToken = default)
		{
			return await _context.Users.ToListAsync();
		}
	}
}

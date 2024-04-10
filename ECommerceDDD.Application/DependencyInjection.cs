using ECommerceDDD.Domain.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceDDD.Application
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddMediatR(cfr =>
			{
				cfr.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly(), typeof(Entity).Assembly);
			});
			return services;
		}

	}
}

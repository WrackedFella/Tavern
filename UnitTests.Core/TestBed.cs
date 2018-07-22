using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tavern.Domain;

namespace UnitTests.Core
{
	public abstract class TestBed
	{
		protected virtual TavernDbContext GenerateContext()
		{
			var serviceProvider = new ServiceCollection()
				.AddEntityFrameworkInMemoryDatabase()
				.AddEntityFrameworkProxies()
				.BuildServiceProvider();

			DbContextOptions<TavernDbContext> options = new DbContextOptionsBuilder<TavernDbContext>()
				.UseInMemoryDatabase("MockDb")
				.UseLazyLoadingProxies()
				//Without this line, data will persist between tests.
				// May be desirable, under certain conditions.
				.UseInternalServiceProvider(serviceProvider)
				.EnableSensitiveDataLogging()
				.Options;

			return new TavernDbContext(options);
		}
	}
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tavern.Domain;
using Xunit;

namespace UnitTests.Core
{
	public abstract class TestBed
	{
		protected virtual TavernIdentityContext GenerateContext()
		{
			var serviceProvider = new ServiceCollection()
				.AddEntityFrameworkInMemoryDatabase()
				.AddEntityFrameworkProxies()
				.BuildServiceProvider();

			DbContextOptions<TavernIdentityContext> options = new DbContextOptionsBuilder<TavernIdentityContext>()
				.UseInMemoryDatabase("MockDb")
				.UseLazyLoadingProxies()
				//Without this line, data will persist between tests.
				// May be desirable, under certain conditions.
				.UseInternalServiceProvider(serviceProvider)
				.EnableSensitiveDataLogging()
				.Options;

			return new TavernIdentityContext(options);
		}
	}
}

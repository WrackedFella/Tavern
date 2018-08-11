using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tavern.Auth.Models;

namespace Tavern.Auth.IdentityContext
{
    public class TavernIdentityContext : IdentityDbContext<TavernUser, TavernRole, Guid>
    {
		public TavernIdentityContext()
		{
		}

		public TavernIdentityContext(DbContextOptions options)
			: base(options)
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Tavern_Development;Integrated Security=True");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			base.OnModelCreating(modelBuilder);
		}
	}
}

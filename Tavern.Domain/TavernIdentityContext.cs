using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tavern.Domain.Auth;
using Tavern.Domain.Characters;

namespace Tavern.Domain
{
	public class TavernIdentityContext : IdentityDbContext<TavernUser, TavernRole, Guid>
	{
		public TavernIdentityContext()
		{
		}

		public TavernIdentityContext(DbContextOptions<TavernIdentityContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Character> Characters { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Tavern_Development;Integrated Security=True");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Character>(x => {
				x.Property(b => b.CharacterId).HasDefaultValueSql("NEWID()");
				x.Property(b => b.CreatedDate).HasDefaultValueSql("GETDATE()");
			});
			
			base.OnModelCreating(modelBuilder);
		}
	}
}

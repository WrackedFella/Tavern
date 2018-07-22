using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using Tavern.Domain.Characters;

namespace Tavern.Domain
{
	public class TavernDbContext : DbContext
	{
		public TavernDbContext()
		{
		}

		public TavernDbContext(DbContextOptions options)
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
				x.Property(b => b.CharacterId)
					.HasDefaultValueSql("newid()")
					.HasValueGenerator<GuidValueGenerator>();
				x.Property(b => b.CreatedDate).HasDefaultValueSql("getdate()");
			});
			
			base.OnModelCreating(modelBuilder);
		}
	}

	public class GuidValueGenerator : ValueGenerator<Guid>
	{
		public override Guid Next(EntityEntry entry)
		{
			return Guid.NewGuid();
		}

		public override bool GeneratesTemporaryValues => false;
	}
}

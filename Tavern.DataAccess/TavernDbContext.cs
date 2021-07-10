using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Tavern.DataAccess.Auth;
using Tavern.DataAccess.Shadowrun;

namespace Tavern.DataAccess
{
    public interface ITavernDbContext
    {
        DbSet<Alias> Aliases { get; set; }
        DbSet<Character> Characters { get; set; }
        DbSet<CharacterSkill> CharacterSkills { get; set; }
        DbSet<CharacterSkillGroup> CharacterSkillGroups { get; set; }
        DbSet<Contact> Contacts { get; set; }
        DbSet<Quality> Qualities { get; set; }
        DbSet<Skill> Skills { get; set; }
        DbSet<SkillGroup> SkillGroups { get; set; }
    }

    public class TavernDbContext : IdentityDbContext<TavernUser, TavernRole, Guid>, ITavernDbContext
    {
        protected TavernDbContext()
        {
        }

        public TavernDbContext(DbContextOptions options) : base(options)
        {
        }

        #region Tables
        
        public virtual DbSet<Alias> Aliases { get; set; }
        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<CharacterSkill> CharacterSkills { get; set; }
        public virtual DbSet<CharacterSkillGroup> CharacterSkillGroups { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Quality> Qualities { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<SkillGroup> SkillGroups { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var et in builder.Model.GetEntityTypes())
            {
                var uid = et.GetProperties().FirstOrDefault(p => p.IsKey());
                if (uid != null && uid.ClrType == typeof(Guid))
                {
                    uid.SetDefaultValueSql("(newid())");
                }

                foreach (var dateProp in et.GetProperties().Where(p => p.ClrType == typeof(DateTimeOffset)))
                {
                    dateProp.SetDefaultValueSql("(getdate())");
                }

                foreach (var decimalProp in et.GetProperties().Where(p => p.ClrType == typeof(decimal)))
                {
                    decimalProp.SetColumnType("decimal(18, 6)");
                }
            }

            base.OnModelCreating(builder);

            builder.Entity<CharacterSkill>(cs =>
            {
                cs.ToTable("CharacterSkills")
                    .HasKey(charSkill => new { charSkill.CharacterId, charSkill.SkillId });
            });

            builder.Entity<CharacterSkillGroup>(csg =>
            {
                csg.ToTable("CharacterSkillGroups")
                    .HasKey(charSkillGroup => new { charSkillGroup.CharacterId, charSkillGroup.SkillGroupId });
            });
        }
    }
}

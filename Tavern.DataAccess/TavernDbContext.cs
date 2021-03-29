using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Tavern.DataAccess.Auth;
using Tavern.DataAccess.Shadowrun;

namespace Tavern.DataAccess
{
    public class TavernDbContext : IdentityDbContext<TavernUser, TavernRole, Guid>
    {
        protected TavernDbContext()
        {
        }

        public TavernDbContext(DbContextOptions options) : base(options)
        {
        }

        #region Tables
        
        public virtual DbSet<Alias> Alias { get; set; }
        public virtual DbSet<Character> Character { get; set; }
        public virtual DbSet<CharacterSkill> CharacterSkill { get; set; }
        public virtual DbSet<CharacterSkillGroup> CharacterSkillGroup { get; set; }
        public virtual DbSet<Contact> Contact { get; set; }
        public virtual DbSet<Quality> Quality { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<SkillGroup> SkillGroup { get; set; }

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

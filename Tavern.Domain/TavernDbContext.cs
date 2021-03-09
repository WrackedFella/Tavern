using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Tavern.Domain.Auth;
using Tavern.Domain.Shadowrun;

namespace Tavern.Domain
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
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace Tavern.DataAccess.Shadowrun
{
    public class CharacterSkill
    {
        [Key]
        public Guid CharacterId { get; set; }
        public Guid SkillId { get; set; }
        public int Rating { get; set; }
    }
}

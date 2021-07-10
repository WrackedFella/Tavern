using System;
using System.Collections.Generic;

namespace Tavern.DataAccess.Shadowrun
{
    public class CharacterSkillGroup
    {
        public Guid CharacterId { get; set; }
        public Guid SkillGroupId { get; set; }
        public int Rating { get; set; }

        public virtual ICollection<CharacterSkill> Skills { get; set; } = new HashSet<CharacterSkill>();
    }
}

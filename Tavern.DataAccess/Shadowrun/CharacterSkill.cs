using System;
using System.Collections.Generic;
using System.Text;

namespace Tavern.DataAccess.Shadowrun
{
    public class CharacterSkill
    {
        public Guid CharacterId { get; set; }
        public Guid SkillId { get; set; }
        public int Rating { get; set; }
    }
}

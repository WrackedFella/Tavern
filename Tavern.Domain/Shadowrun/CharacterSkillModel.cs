using System;
using System.Collections.Generic;
using System.Text;

namespace Tavern.Domain.Shadowrun
{
    public class CharacterSkillModel
    {
        public Guid CharacterId { get; set; }
        public Guid SkillId { get; set; }
        public int Rating { get; set; }
    }
}

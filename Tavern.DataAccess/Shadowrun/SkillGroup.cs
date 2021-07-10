using System;
using System.Collections.Generic;

namespace Tavern.DataAccess.Shadowrun
{
    public class SkillGroup
    {
        public Guid SkillGroupId { get; set; }
        public Guid AttributeId { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }

        public virtual ICollection<Skill> Skills { get; set; } = new HashSet<Skill>();
    }
}

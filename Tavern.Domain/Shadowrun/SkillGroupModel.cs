using System;
using System.Collections.Generic;
using System.Text;

namespace Tavern.Domain.Shadowrun
{
    public class SkillGroupModel
    {
        public Guid SkillGroupId { get; set; }
        public Guid AttributeId { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }

        public virtual ICollection<SkillModel> Skills { get; set; } = new HashSet<SkillModel>();
    }
}

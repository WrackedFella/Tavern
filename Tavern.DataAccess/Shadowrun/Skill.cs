using System;

namespace Tavern.DataAccess.Shadowrun
{
    public class Skill
    {
        public Guid SkillId { get; set; }
        public Guid SkillGroupId { get; set; }
        public Guid AttributeId { get; set; }
        public string Name { get; set; }
        public int Rating { get; set; }
    }
}

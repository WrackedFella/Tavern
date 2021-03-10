using System;
using System.Collections.Generic;
using System.Text;
using Tavern.DataAccess.Enums;
using Tavern.DataAccess.GameObjects;

namespace Tavern.DataAccess.Shadowrun
{
    public class Character : CharacterBase
    {
        public Guid CharacterId { get; set; }
        public Metatype Metatype { get; set; }
        public int StreetCred { get; set; }
        public int Notoriety { get; set; }
        public int PublicAwareness { get; set; }

        public virtual ICollection<Alias> Aliases { get; set; } = new HashSet<Alias>();
        public virtual ICollection<Contact> Contacts { get; set; } = new HashSet<Contact>();
        public virtual ICollection<CharacterSkillGroup> Skills { get; set; } = new HashSet<CharacterSkillGroup>();
        public virtual ICollection<Quality> Qualities { get; set; } = new HashSet<Quality>();

        //public void AdvanceSkillGroup(SkillGroup sg, int karma)
        //{
        //    var currentSg = this.Skills.FirstOrDefault(x => x.CharacterSkillGroupId == sg.CharacterSkillGroupId);
        //    foreach (var s in currentSg.Skills)
        //    {
        //        Func<Skill, int> functionOfKarmaAndSkillThing;
        //        s.Advance(functionOfKarmaAndSkillThing);

        //    }
        //}
    }
}

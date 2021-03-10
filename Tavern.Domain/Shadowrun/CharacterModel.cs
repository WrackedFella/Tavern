using System;
using System.Collections.Generic;
using Tavern.DataAccess.Enums;
using Tavern.DataAccess.GameObjects;

namespace Tavern.Domain.Shadowrun
{
    public class CharacterModel : CharacterBase
    {
        public Guid CharacterId { get; set; }
        public Metatype Metatype { get; set; }
        public int StreetCred { get; set; }
        public int Notoriety { get; set; }
        public int PublicAwareness { get; set; }

        public virtual ICollection<AliasModel> Aliases { get; set; } = new HashSet<AliasModel>();
        public virtual ICollection<ContactModel> Contacts { get; set; } = new HashSet<ContactModel>();
        public virtual ICollection<CharacterSkillGroupModel> Skills { get; set; } = new HashSet<CharacterSkillGroupModel>();
        public virtual ICollection<QualityModel> Qualities { get; set; } = new HashSet<QualityModel>();

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

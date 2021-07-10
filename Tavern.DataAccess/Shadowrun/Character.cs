using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tavern.DataAccess.Core;
using Tavern.DataAccess.GameObjects;
using Tavern.DataAccess.Shadowrun.Attributes;

namespace Tavern.DataAccess.Shadowrun
{
    public class Character : CharacterBase
    {
        [Key]
        public Guid CharacterId { get; set; }
        
        #region Character Details
        public Metatype Metatype { get; set; } = Metatype.Human;
        public int StreetCred { get; set; } = 0;
        public int Notoriety { get; set; } = 0;
        public int PublicAwareness { get; set; } = 0;
        #endregion

        #region Attributes

        [Physical]
        public int Body { get; set; }
        [Physical]
        public int Agility { get; set; }
        [Physical]
        public int Reaction { get; set; }
        [Physical]
        public int Strength { get; set; }

        [Mental]
        public int Willpower { get; set; }
        [Mental]
        public int Logic { get; set; }
        [Mental]
        public int Intuition { get; set; }
        [Mental]
        public int Charisma { get; set; }

        #endregion

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

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tavern.DataAccess.GameObjects;
using Tavern.DataAccess.Shadowrun.Attributes;
using static Tavern.DataAccess.Shadowrun.Attributes.AttributeCategoryAttribute;

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


        // These have special rules surrounding them in the core rulebook. 
        //public int PhysicalConditionMonitor { get; set; }
        //public int StunConditionMonitor { get; set; }

        #region Attributes

        [AttributeCategory(AttributeCategory.Physical)]
        public int Body { get; set; }
        [AttributeCategory(AttributeCategory.Physical)]
        public int Agility { get; set; }
        [AttributeCategory(AttributeCategory.Physical)]
        public int Reaction { get; set; }
        [AttributeCategory(AttributeCategory.Physical)]
        public int Strength { get; set; }


        [AttributeCategory(AttributeCategory.Mental)]
        public int Willpower { get; set; }
        [AttributeCategory(AttributeCategory.Mental)]
        public int Logic { get; set; }
        [AttributeCategory(AttributeCategory.Mental)]
        public int Intuition { get; set; }
        [AttributeCategory(AttributeCategory.Mental)]
        public int Charisma { get; set; }


        [AttributeCategory(AttributeCategory.Special)]
        public int Edge { get; set; } // For doing cool shit, regardless of archetype
        [AttributeCategory(AttributeCategory.Special)]
        public int Essence { get; set; } // For mages
        [AttributeCategory(AttributeCategory.Special)]
        public int Initiative { get; set; } // For combat
        [AttributeCategory(AttributeCategory.Special)]
        public int Magic { get; set; } // For mages
        [AttributeCategory(AttributeCategory.Special)]
        public int Resonance { get; set; } // For Technomancers

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

using System;

namespace Tavern.DataAccess.GameObjects
{
    public abstract class CharacterBase
    {
        // Personal Data
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; } = new Random().Next(21, 55);
        public Gender Gender { get; set; } = Gender.Male;
        public decimal Height { get; set; } = 6;
        public decimal Weight { get; set; } = 160;

        public int Experience { get; set; } = 0;
        public decimal Money { get; set; } = 0;

    }
}

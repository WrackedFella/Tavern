using System;
using System.Collections.Generic;
using System.Text;
using Tavern.DataAccess.Enums;

namespace Tavern.DataAccess.GameObjects
{
    public abstract class CharacterBase
    {
        // Personal Data
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }

        public int Experience { get; set; }
        public decimal Money { get; set; }

    }
}

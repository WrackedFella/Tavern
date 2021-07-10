using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tavern.DataAccess.Common
{
    public class CharacterName
    {
        [Key]
        public Guid CharacterNameId { get; set; }
        public TypeOfName TypeOfName { get; set; }
        public string Name { get; set; }
        public GameSystem? GameSystem { get; set; }
        public string Origins { get; set; } // Italian, Russian, etc.
        
        // Unsure how we'd do this. What would the denominator be? 
        //  Idea: implement in the Domain? Maybe the concept of name groups is a purely domain-level concern.
        // public decimal Probability { get; set; }
    }
}

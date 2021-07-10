using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tavern.DataAccess.Types
{
    public class ShadowrunAttribute
    {
        public enum AttributeCategory
        {
            Physical,
            Mental,
            Special
        }

        public AttributeCategory Category { get; set; }
        public string Name { get; set; }
        public string Abbreviation => string.IsNullOrEmpty(Name) 
            ? throw new NullReferenceException("Attribute is missing a name.") 
            : Name.Substring(0, 3).ToUpper();
        public int Rating { get; set; }

    }
}

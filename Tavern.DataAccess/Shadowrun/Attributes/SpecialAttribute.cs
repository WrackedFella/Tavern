﻿using System;

namespace Tavern.DataAccess.Shadowrun.Attributes
{

    public class AttributeCategoryAttribute : Attribute
    {
        public enum AttributeCategory
        {
            Physical,
            Mental,
            Special
        }

        public AttributeCategory Category { private set; get; }

        public AttributeCategoryAttribute(AttributeCategory category)
        {
            this.Category = category;
        }
    }
}

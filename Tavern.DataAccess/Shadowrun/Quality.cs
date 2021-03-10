using System;
using System.Collections.Generic;
using System.Text;

namespace Tavern.DataAccess.Shadowrun
{
    public class Quality
    {
        public Guid QualityId { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public int Rating { get; set; }
        public int KarmaModifier { get; set; }
        public bool IsPositiveQuality => KarmaModifier >= 0;
        public bool IsNegativeQuality => KarmaModifier < 0;
    }
}

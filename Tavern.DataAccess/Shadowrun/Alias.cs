using System;
using System.ComponentModel.DataAnnotations;

namespace Tavern.DataAccess.Shadowrun
{
    public class Alias
    {
        [Key]
        public Guid AliasId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Notes { get; set; } 
    }
}

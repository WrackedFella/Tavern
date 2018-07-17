using System.ComponentModel.DataAnnotations;
using Shared;

namespace Tavern.Domain.Characters
{
	public class Character : AuditEntityBase
	{
		[Required, MinLength(2), MaxLength(100)]
		public string Name { get; set; }

		[MaxLength(255)]
		public string Description { get; set; }
	}
}

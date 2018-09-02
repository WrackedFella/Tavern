using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared;

namespace Tavern.Domain.Characters
{
	public class Character : AuditModelBase
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid CharacterId
		{
			get => this.Id;
			set => this.Id = value;
		}

		[Required, MinLength(2), MaxLength(100)]
		public string Name { get; set; }

		[MaxLength(255)]
		public string Description { get; set; }
	}
}

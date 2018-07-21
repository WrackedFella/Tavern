using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared
{
	public abstract class EntityBase
	{
		protected Guid Id { get; set; }
	}
}

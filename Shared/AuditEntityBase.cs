using System;

namespace Shared
{
	public abstract class AuditEntityBase : EntityBase
	{
		public string CreatedBy { get; set; }
		public DateTimeOffset CreatedDate { get; set; } = new DateTimeOffset();
		public string ModifiedBy { get; set; }
		public DateTimeOffset ModifiedDate { get; set; } = new DateTimeOffset();
	}
}

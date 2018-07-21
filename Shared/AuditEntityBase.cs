using System;

namespace Shared
{
	public abstract class AuditEntityBase : EntityBase
	{
		public string CreatedBy { get; set; }
		public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.Now;
		public string ModifiedBy { get; set; }
		public DateTimeOffset? ModifiedDate { get; set; }
	}
}

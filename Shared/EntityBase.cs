using System;

namespace Shared
{
	public abstract class ModelBase
	{
		protected Guid Id { get; set; }

		public Guid GetId() => this.Id;
	}

	// TKey supports non-guid keys, like composite keys.
	public abstract class ModelBase<TKey>
	{
		protected TKey Id { get; set; }

		public TKey GetId() => this.Id;
	}
}

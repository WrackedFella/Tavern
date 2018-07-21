using System;

namespace Shared
{
	public abstract class ModelBase
	{
		/// <summary>
		/// The Model's unique identifier. Not necessarily the Entitie's. 
		/// </summary>
		public virtual Guid Id { get; set; }
	}
}

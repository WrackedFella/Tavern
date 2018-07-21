using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
	public abstract class ModelBase<T>
	{
		protected virtual T Id { get; set; }
	}
}

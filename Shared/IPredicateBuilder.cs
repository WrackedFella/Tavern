using System;
using System.Linq.Expressions;

namespace Shared
{
	public interface IPredicateBuilder<T> where T : class
	{
		Expression<Func<T, bool>> BuildPredicate();
	}
}

using System.Collections.Generic;

namespace UnitTests.Core
{
	public class ExpectedResult
	{
		public ExpectedResult(params KeyValuePair<string, int>[] expected)
		{
			foreach (KeyValuePair<string, int> e in expected)
			{
				this.Checks.Add(e.Key, e.Value);
			}
		}

		public Dictionary<string, int> Checks = new Dictionary<string, int>();
	}
}

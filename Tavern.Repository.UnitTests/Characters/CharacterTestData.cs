using System.Collections;
using System.Collections.Generic;
using Tavern.Domain.Characters;
using Tavern.Repository.Characters.Models;
using UnitTests.Core;

namespace Tavern.Repository.UnitTests.Characters
{
	public class CharacterTestData : IEnumerable<object[]>
	{
		private readonly KeyValuePair<Character, CharacterModel> _testCase1 =
			new KeyValuePair<Character, CharacterModel>(
			new Character
			{
				Name = "Test 1",
				Description = "Test 1"
			},
			new CharacterModel
			{
				Name = "Test 1",
				Description = "Test 1"
			});

		public IEnumerator<object[]> GetEnumerator()
		{
			yield return new object[]
			{
				new TestCase<CharacterModel> {
					Expected = this._testCase1.Value,
					Data = this._testCase1.Key
				}
			};
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}

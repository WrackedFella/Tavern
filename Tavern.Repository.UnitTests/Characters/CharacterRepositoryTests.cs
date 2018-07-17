using System.Linq;
using System.Threading.Tasks;
using Tavern.Domain;
using Tavern.Domain.Characters;
using Tavern.Repository.Characters.Models;
using Tavern.Repository.Characters.Repositories;
using UnitTests.Core;
using Xunit;

namespace Tavern.Repository.UnitTests.Characters
{
	public class CharacterRepositoryTests : TestBed
	{
		public TavernIdentityContext BuildContext(params Character[] characters)
		{
			var context = GenerateContext();
			if (characters.Length == 0)
			{
				return context;
			}

			context.Characters.AddRange(characters);
			context.SaveChanges();
			return context;
		}

		[Theory]
		[ClassData(typeof(CharacterTestData))]
		public async Task TestProfileMapping(TestCase<CharacterModel> testCase)
		{
			var context = this.BuildContext(new[] { (Character)testCase.Data });
			var repo = new CharacterRepository(context);

			var testResult = (await repo.List()).Single();

			Assert.NotNull(testResult);
			Assert.Equal(testResult.Name, testCase.Expected.Name);
			Assert.Equal(testResult.Description, testCase.Expected.Description);
		}
	}
}

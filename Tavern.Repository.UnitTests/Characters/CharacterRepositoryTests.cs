using System.Linq;
using System.Threading.Tasks;
using Tavern.Domain;
using Tavern.Domain.Characters;
using Tavern.Repository.Characters;
using UnitTests.Core;
using Xunit;

namespace Tavern.Repository.UnitTests.Characters
{
	public class CharacterRepositoryTests : TestBed
	{
		public TavernDbContext BuildContext(params Character[] characters)
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
			// Arrange
			var context = BuildContext(new[] { (Character)testCase.Data });
			using (var repo = new CharacterRepository(context))
			{
				// Act
				var testResult = (await repo.List()).Single();

				// Assert
				Assert.NotNull(testResult);
				Assert.Equal(testResult.Name, testCase.Expected.Name);
				Assert.Equal(testResult.Description, testCase.Expected.Description);
			}
		}

		[Fact]
		public async Task Insert_GivenNewCharacter_ReturnsCharacter()
		{
			var context = BuildContext();
			using (var repo = new CharacterRepository(context))
			{
				var result = await repo.Insert(new CharacterModel());

				Assert.NotNull(result);
				Assert.Single(result);
			}
		}

		[Fact]
		public async Task Update_GivenNewName_ReturnsCharacterWithNewName()
		{
			const string newName = "John";
			var context = BuildContext(new Character { Name = newName });
			var id = context.Characters.First().CharacterId;
			using (var repo = new CharacterRepository(context))
			{
				var result = await repo.Update(id, new CharacterModel { Name = newName });

				Assert.NotNull(result);
				Assert.Equal(newName, result.Name);
			}
		}
	}
}

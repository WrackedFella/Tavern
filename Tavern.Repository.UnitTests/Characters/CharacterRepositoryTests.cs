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
			// Arrange
			var context = this.BuildContext(new[] { (Character)testCase.Data });
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
	        var context = this.BuildContext();
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
	        var newName = "John";
	        var context = this.BuildContext(new Character { Name = newName });
		    using (var repo = new CharacterRepository(context))
			{
				var result = await repo.Update(new CharacterModel {Name = newName});

				Assert.NotNull(result);
				Assert.Equal(newName, result.Name);
			}
		}
    }
}

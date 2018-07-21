using Tavern.Domain.Characters;
using System.Threading.Tasks;
using Tavern.Domain;
using Tavern.Repository.Characters.Models;
using Tavern.Services.Characters;
using UnitTests.Core;
using Xunit;

namespace Tavern.Services.UnitTests.Characters
{
	public class CharacterServiceTests : TestBed
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

		[Fact]
		public async Task CreateCharacter_GivenNewCharacter_ReturnsCharacter()
		{
			var context = this.BuildContext();
			var service = new CharacterService(context);

			var result = await service.Insert(new CharacterModel());

			Assert.NotNull(result);
		}
	}
}

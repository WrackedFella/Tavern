using UnitTests.Core;
using Xunit;
using Tavern.Domain;
using Tavern.Domain.Characters;
using Newtonsoft.Json;
using Tavern.Ui.Json.Serialization;

namespace Tavern.UI.UnitTests
{
	public class CharacterControllerTests : TestBed
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

		[Fact]
		public void ValidationSerializerTest_MetaValidatorConverter()
		{
			string validatorsResponseheader = JsonConvert.SerializeObject(new Character(), Formatting.None, new MetaValidatorConverter());

			Assert.Contains("RequiredAttribute", validatorsResponseheader); // a_request.Headers["validator"]
			Assert.Contains("MinLengthAttribute", validatorsResponseheader); // a_request.Headers["validator"]
			Assert.Contains("MaxLengthAttribute", validatorsResponseheader);
		}
	}
}

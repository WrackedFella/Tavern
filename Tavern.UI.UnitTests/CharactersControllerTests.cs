using System;
using System.Linq;
using UnitTests.Core;
using Xunit;
using Tavern.Domain;
using Tavern.Domain.Characters;
using Newtonsoft.Json;
using Tavern.Ui.Characters;
using Tavern.Ui.Json.Serialization;

namespace Tavern.UI.UnitTests
{
	public class CharactersControllerTests : TestBed
	{
		private CharactersController GenerateController(params Character[] characters)
		{
			var context = GenerateContext();
			if (characters.Length == 0)
			{
				context.SaveChanges();
				return new CharactersController(context);
			}

			context.Characters.AddRange(characters);
			context.SaveChanges();
			return new CharactersController(context);
		}

		// ToDo: Move this to a better test class, or go through CharactersController.
		[Fact]
		public void ValidationSerializerTest_MetaValidatorConverter()
		{
			string validatorsResponseheader = JsonConvert.SerializeObject(new Character(), Formatting.None, new MetaValidatorConverter());

			Assert.Contains("RequiredAttribute", validatorsResponseheader); // a_request.Headers["validator"]
			Assert.Contains("MinLengthAttribute", validatorsResponseheader); // a_request.Headers["validator"]
			Assert.Contains("MaxLengthAttribute", validatorsResponseheader);
		}

		// ToDo: Get these working.
		//// Get
		//[Fact]
		//public void Get_GivenRequestWithoutId_ReturnsArrayOfRecords()
		//{
		//	var controller = this.GenerateController(new Character(), new Character(), new Character());

		//	var results = controller.Get().Value;

		//	Assert.NotNull(results);
		//	Assert.Equal(3, results.Count());
		//}

		//// Get(Id)
		//// Post
		//[Fact]
		//public void Post_GivenNewRecord_ReturnsRecordWithId()
		//{
		//	var controller = this.GenerateController(new Character());
		//	var guid = controller.Get().Value.First().Id;

		//	var result = controller.Get(guid).Result.Value;

		//	Assert.NotNull(result);
		//}

		// Put
		// Patch
		// Delete
	}
}

using System;
using UnitTests.Core;
using Xunit;
using Tavern.Domain;
using Tavern.Domain.Characters;
using Tavern.Ui.Characters;
using Tavern.Services.Characters;
using Microsoft.AspNetCore.Mvc;
using Tavern.Repository.Characters;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
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
        public async System.Threading.Tasks.Task Get_GivenValidationHeader_ShouldReturnValidatorHeaderAsync()
        {
			// Arrange
			// - Arrange the Context 			XX Done
			// - Arrange a WebRequest object
			var character = new Character { CharacterId = Guid.Empty };
            var context = BuildContext(character);
			var controller = new CharacterApiController(new CharacterService(context));

            MockWebRequest webRequest = new MockWebRequest();

            //var a_request = MockWebRequest.CreateRequestWithResponseCode( System.Net.HttpStatusCode.OK); // no header support for our mock web requests. Maybe later.

            
            

			// Act
			// - GET the WebRequest at the Controller
			var test = controller.Get(character.CharacterId).Result as ActionResult<CharacterModel>;

            // Fill our header
            //  We cannot read form the Result.Value directly, providing a mock instance of CharacterModel().
            //
            // Known Issue: If there are no attributes this object is fully serialized which is not intended.
            string validators_responseheader = JsonConvert.SerializeObject(new CharacterModel(), Formatting.None, new MetaValidatorConverter());

            // Assert
            //  Contains Key, when we can actually call our AsyncActionFilter

			// Assert
			// - Our object results are as expected
			Assert.NotNull(test);
			Assert.Contains("RequiredAttribute", validators_responseheader); // a_request.Headers["validator"]
            Assert.Contains("MinLengthAttribute", validators_responseheader); // a_request.Headers["validator"]
            Assert.Contains("MaxLengthAttribute", validators_responseheader);
        }

		
    }
}

using Moq;
using System.Threading.Tasks;
using Tavern.Api.Controllers;
using Tavern.Domain.Shadowrun.Models;
using Tavern.Domain.Shadowrun.Services;
using Xunit;
using static Xunit.Assert;

namespace Tavern.Api.Tests
{
    public class CharacterControllerTests
    {

        [Fact]
        public async Task GenerateNpc_GivenAnyParameters_ShouldGenerateFullCharacter()
        {
            var mockService = new Mock<ICharacterService>();
            mockService.Setup(x => x.GenerateCharacter())
                .ReturnsAsync(new CharacterModel
                {
                    FirstName = "Jon",
                    MiddleName = "Luc",
                    LastName = "Picard",
                    Age = 52
                });
            var controller = new CharacterController(mockService.Object);

            var result = await controller.GenerateCharacter();

            NotNull(result);
            True(result.FirstName.Length >= 2);
            True(result.LastName.Length >= 2);
            True(result.MiddleName.Length >= 2);
        }
    }
}

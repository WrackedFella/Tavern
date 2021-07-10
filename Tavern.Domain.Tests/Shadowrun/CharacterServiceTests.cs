using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tavern.DataAccess;
using Tavern.DataAccess.Shadowrun;
using Tavern.Domain.Shadowrun.Services;
using Xunit;
using static Xunit.Assert;

namespace Tavern.Domain.Tests.Shadowrun
{
    public class CharacterServiceTests : TestBed
    {
        [Fact]
        public async Task GenerateNpc_GivenAnyParameters_ShouldGenerateFullCharacter()
        {
            var mockContext = new Mock<TavernDbContext>();
            // ToDo: Mock out the other things we'd want to include
            mockContext.Setup(x => x.Characters)
                .Returns(GenerateMockDbSet(new List<Character>
                    {
                        new Character()
                    }));

            var service = new CharacterService(mockContext.Object);
            var result = await service.GenerateCharacter();

            // ToDo: Other Asserts. 
            NotNull(result);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Tavern.DataAccess.Shadowrun;
using Tavern.Domain.Shadowrun.Services;

namespace Tavern.Api.Controllers
{
    [ApiController]
    [Route(BaseRoute)]
    public class CharacterController : Controller
    {
        public const string BaseRoute = "Shadowrun/[controller]";

        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            this._characterService = characterService;
        }

        [HttpGet]
        public async Task<Character> GenerateCharacter() => await this._characterService.GenerateCharacter();
    }
}

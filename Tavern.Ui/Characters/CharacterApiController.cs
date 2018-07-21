using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tavern.Repository.Characters.Models;
using Tavern.Services;
using Tavern.Ui.Core;

namespace Tavern.Ui.Characters
{
	[AllowAnonymous]
	[Route("api/characters")]
    public class CharacterApiController : TavernControllerBase<CharacterModel>
	{
		public CharacterApiController(IService<CharacterModel> service) : base(service)
		{
		}
	}
}

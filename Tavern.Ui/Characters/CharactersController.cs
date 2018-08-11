using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tavern.Repository.Characters;
using Tavern.Services;
using Tavern.Ui.Core;

namespace Tavern.Ui.Characters
{
	public class CharactersController : TavernControllerBase<CharacterModel>
	{
		public CharactersController(IService<CharacterModel> service) : base(service)
		{
		}
	}
}
